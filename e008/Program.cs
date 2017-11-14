/*******************************************************************************************************
 * What is the sum of all integers greater than 10 and less than 100000000 that are prime forward and backward?
 *      29239803893782
 
 "I got 29239804063739." - Will Watson 
  */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e008 {
    class e008 {
        static void Main(string[] args) {
            long upperLimit = 100000000;
            Console.WriteLine("e008: " + (new e008()).Solve(upperLimit));
        }
        public long Solve(long upperLimit) {
            long result = 0;
            long reverseI;
            char[] myArray;
            String myString;
            char firstDigit;
            //result = 17;    // Our loop begins at 11, so add in 2+3+5+7 . 
            for (long i = 11; i < upperLimit; i += 2) {
                if ((i % 1000001) == 0) { Console.WriteLine(i); }
                myString = Convert.ToString(i);
                myArray = myString.ToCharArray();
                firstDigit = myArray[myArray.Length-1];
                if (firstDigit == '1' || firstDigit == '3' || firstDigit == '7' || firstDigit == '9') {
                    Array.Reverse(myArray);
                    myString = new String(myArray);
                    reverseI = Convert.ToInt64(myString);
                    if (IsPrime(i) && IsPrime(reverseI)) {
                        //Console.WriteLine(i + ":" + reverseI);
                        result += i;
                    }
                } else {
/*
                    // The number begins with {2,4,5,6,8} so skip ahead to the next number that doesn't
                    Console.Write("i = " + i);
                    myArray[0] += (char)1;
                    for (int j = 1; j < myArray.Length - 1; j++) { myArray[j] = '0'; } myArray[myArray.Length - 1] = '1';
                    i = Convert.ToInt64(new String(myArray));
                    Console.WriteLine(", " + i); */
                }
            }
            return result;
        }
        private static bool IsPrime(long num) {
            bool result = true;
            if (num == 0) return false;
            if (num == 1) return false;
            if (num == 2) return false;
            if ((num % 2) == 0) return false;
            /*
                        //          if (num == 2) return true;
                        int lastDigit = (int)(num - ((num / 10) * 10));
                        if (lastDigit == 0 || lastDigit == 2 || lastDigit == 4 || lastDigit == 5 || lastDigit == 6 || lastDigit == 8) return false;
                        //          if (num % 2 == 0) return false;
                        if (num % 3 == 0) return false;
                        //          if (num % 5 == 0) return false;
                        if (num % 7 == 0) return false;
                        if (num % 11 == 0) return false;
                        if (num % 13 == 0) return false;
                        if (num % 17 == 0) return false;
                        if (num % 19 == 0) return false;
                        if (num % 23 == 0) return false;
                        if (num % 29 == 0) return false;
                        if (num % 31 == 0) return false;
                        if (num % 37 == 0) return false;
                        if (num % 41 == 0) return false;
                        if (num % 43 == 0) return false;
                        if (num % 47 == 0) return false;
                        if (num % 53 == 0) return false;
                        if (num % 59 == 0) return false;
            */
            long limit = (int)Math.Sqrt(num) + 1;
            for (long i = 3; i < limit; i += 2) {
                if ((num % i) == 0) { result = false; break; }
            }
            return result;
        }
    }
}
