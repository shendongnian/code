    public void ExampleSub(string Test, 
      System.Nullable<DateTime> fromDate = DateTime.MinValue)
    {
        fromDate = fromDate == DateTime.MinValue ? System.DateTime.Now : fromDate;
        //A Great sub!
    }
