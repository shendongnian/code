    private DateTime MyModelDateTime;
    public string date
    {
     get
     {
       return MyModelDateTime.ToString("MM/dd/yyyy"); 
     }
     set
     {
       string pattern = "MM/dd/yyyy HH:mm:ss";
       string timeValue = MyModelDateTime.ToString("HH:mm:ss");
       string dateTimeValue = value + " " +timeValue;
       MyModelDateTime = DateTime.ParseExact(dateTimeValue, pattern, null, DateTimeStyles.None)
     }
    }
    
    public string time
    {
     get
     {
       return MyModelDateTime.ToString("HH:mm:ss"); 
     }
     set
     {
       string pattern = "MM/dd/yyyy HH:mm:ss";
       string dateValue = MyModelDateTime.ToString("MM/dd/yyyy");
       string dataTimeValue = dateValue + " " + value;
       MyModelDateTime = DateTime.ParseExact(dateTimeValue, pattern, null, DateTimeStyles.None)
     }
    }
