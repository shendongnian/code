    //you might use TryConvert or a Try block here to validate your string data...
    int beginYear = Integer.Convert(strBeginYear);
    int beginMonth = Integer.Convert(strBeginMonth);
    int endYear = Integer.Convert(strEndYear);
    int endMonth = Integer.Convert(strEndMonth);
    DateTime start = new DateTime(beginYear, beginMonth, 1);
    DateTime endLimit = new DateTime(endYear, endMonth, 1).AddMonths(1);
    
    dollartotals = (from x in se.AchBatches
          where x.CompanyCode == company &&
                x.DateTimeSubmitted >= start &&
    			x.DateTimeSubmitted < endLimit
          select x.DollarTotal).Sum();
