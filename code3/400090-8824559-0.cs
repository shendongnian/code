    //The values from the DB
    var values = new List<DateValue>()
    { 
        new DateValue(){ Date = new DateTime(2012, 1, 12), Value = 5000 },  
        new DateValue(){ Date = new DateTime(2012, 11, 15), Value = 3000 }
    };
        
    var year = DateTime.Now.Year;
    var cal = System.Threading.Thread.CurrentThread.CurrentCulture.Calendar;
    
    //Generate the months and dates and left join with the values from the DB
    var q = from month in Enumerable.Range(1, cal.GetMonthsInYear(year))
            select new
            {
                Dates = from date in Enumerable.Range(1, 
                            cal.GetDaysInMonth(year, month))
                            .Select(day => new DateTime(year, month, day))
                        join tmp in values on date equals tmp.Date into g
                        from value in g.DefaultIfEmpty()
                        select new
                        {
                            Date = date,
                            Value = value == null ? new Nullable<Decimal>() : value.Value
                        }
            };
    
    //bind the query to the outer repeater
    repMonths.DataSource = q;
    repMonths.DataBind();
