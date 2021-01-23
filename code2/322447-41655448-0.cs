      /// <summary>
      /// Method to convert an integer to a string containing the number in binary. A negative 
      /// number will be formatted as a 32-character binary number in two's compliment.
      /// </summary>
      /// <param name="theNumber">self-explanatory</param>
      /// <param name="minimumDigits">if binary number contains fewer characters leading zeros are added</param>
      /// <returns>string as described above</returns>
      public static string IntegerToBinaryString(int theNumber, int minimumDigits)
      {
         return Convert.ToString(theNumber, 2).PadLeft(minimumDigits, '0');
      }
