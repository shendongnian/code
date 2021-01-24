    using System;
    
    class MainClass {
      public static void Main () {
        int myNumber = 123456789;  //store original number
        int newNumber = (int)Math.Abs(myNumber);  //changes the number to positive if it is negative to prevent string formatting errors.
        int product = 1; //store product start point
        string myString = newNumber.ToString(); //convert number to string
        foreach(char number in myString){  //loop through string
          string numberString = number.ToString();  //convert chars to strings to ensure proper output
          int oneDigit = Convert.ToInt32(numberString); //convert strings to integers
          product = product*oneDigit;  //multiply each integer by the product and set that as the new product
        }
        if(myNumber < 0){product = -product;} 
        //if the number is negative, the result will be negative, since it is a negative followed by a bunch of positives.
        //If you want your result to reflect that, add the above line to account for negative numbers.
        Console.WriteLine(product);  //display product
      }
    }
    Output>>> 362880  //The output that was printed.
