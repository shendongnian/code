        using System;
        using System.Globalization;
        public class Test
        {
    	public static void Main()
    	{		
    		CultureInfo provider = new CultureInfo("en");
    	    DateTime dt =	DateTime.ParseExact("040415","ddMMyy", provider);
      Console.WriteLine(dt.Year.ToString());
    	}
    }
