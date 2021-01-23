    public DateTime? BirthDay
    {
      get
      {
        DateTime result;
        if(DateTime.TryParse(BirthDayString,out result))
          return result;
        else
          return null;
       }
    }
