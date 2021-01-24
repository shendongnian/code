     public void ValidateDateTimeString(string datetime)
     {
    	    DateTime result = new DateTime(); //If Parsing succeed, it will store date in result variable.
            if(DateTime.TryParseExact(datetime, "yyyy-MM-ddTHH:mm:ss.fffzzz", CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
     		    Console.WriteLine("Valid date String");
	        else
     		    Console.WriteLine("Invalid date string");
     }
