      int number;
      bool result = Int32.TryParse(tx.Text, out number);
      if (result)
      {
          // Conversion to a number was successful.
          // The number variable contains your value.        
      }
      else
      {
         // Conversion to a number failed.
         // The value entered in the textbox is not numeric.
      }
