    private DateTime getDate(string yyyyMmDd, DateTime defaultValue)
    {
      DateTime ret  = DateTime.MinValue;
      if (!DateTime.TryParse(yyyyMmDd, out ret)) 
         return defaultValue;
    
      return ret;
    }
    
    var to = DateTime.Parse(tb_DateTo.Text);
    var from  = DateTime.Parse(tb_DateFrom.Text);
    journeys.Where(j=> getDate(j.DateFrom, DateTime.MaxValue) <= from && getDate(j.DateTo, DateTime.MinValue) >= to);
