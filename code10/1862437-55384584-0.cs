    using System;
    
    class MainClass {
      public static void Main () {
        int myNumber = 123456789;
        int product = 1;
        string myString = myNumber.ToString();
        foreach(char number in myString){
          string numberString = number.ToString();
          int oneDigit = Convert.ToInt32(numberString);
          product = product*oneDigit;
        }
        Console.WriteLine(product);
      }
    }
