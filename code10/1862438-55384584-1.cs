    using System;
    
    class MainClass {
      public static void Main () {
        int myNumber = 123456789;  //store original number
        int product = 1; //store product start point
        string myString = myNumber.ToString(); //convert number to string
        foreach(char number in myString){  //loop through string
          string numberString = number.ToString();  //convert chars to strings to ensure proper output
          int oneDigit = Convert.ToInt32(numberString); //convert strings to integers
          product = product*oneDigit;  //multiply each integer by the product and set that as the new product
        }
        Console.WriteLine(product);  //display product
      }
    }
