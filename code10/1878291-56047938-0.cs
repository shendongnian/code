     public static string getProcedureEndingDateTime (string input) {
    	string[] parts = input.Split('|');
        string myDate = parts[0];
        DateTime myDateTime = DateTime.Parse (myDate);
    
        string myTime = parts[1];
        if (!int.TryParse(myTime.Substring(0,2), out int hours))
            hours = 0;
        if (!int.TryParse(myTime.Substring(2,2), out int minutes))
            minutes = 0;
        TimeSpan myTimeSpan = new TimeSpan(hours, minutes, 0);
    
        myDateTime += myTimeSpan;
    
        return myDateTime.ToString();
    }
