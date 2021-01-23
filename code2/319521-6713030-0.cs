      string mytxtCHI = txtID.Text;
      int number;
      bool result = Int32.TryParse(mytxtCHI , out number);
      if (result)
      {
         Console.WriteLine("Converted '{0}' to {1}.", mytxtCHI , number);         
      }
      else
      {
         if (value == null) value = ""; 
         Console.WriteLine("Attempted conversion of '{0}' failed.", mytxtCHI );
      }
