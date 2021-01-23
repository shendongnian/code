    public string DueDate {
      get {return Due.Date.ToShortDateString();}
      set { Due.Date = DateTime.Parse(value); }
    }
    public string DueTimeHour{
      get {return Due.Hours}
      set { Due.Hours = Int32.Parse(value); }
    }
    ...
