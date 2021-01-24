    decimal number;
	string value = "";
	if(!String.IsNullOrEmpty(value))
	{
			
      if(Decimal.TryParse(value, out number))
       {
         Console.WriteLine("Converted '{0}' to {1}.", value, number);
		}
		else
		{
          Console.WriteLine("Unable to convert '{0}'.", value);
		}
    }
