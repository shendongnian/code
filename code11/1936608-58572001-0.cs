    public DataTable FilterTable(DataTable table, DateTime startDate, DateTime endDate)
        {
            var filteredRows =
                from row in table.Rows.OfType<DataRow>()
                where (DateTime)row["sDate"] < endDate && startDate <= (DateTime)row["eDate"]
                select row;
            var filteredTable = table.Clone();
            filteredRows.ToList().ForEach(r => filteredTable.ImportRow(r));
            return filteredTable;
        }
    public TimeSpan TimeNightRest(DateTime WhatDay, int dayRange, DataTable TimeData)
        {
            DateTime DayRangeStart = DateTime.Parse(WhatDay.ToShortDateString());
            DateTime DayRangeEnd = DateTime.Parse(DayRangeStart.AddDays(dayRange).ToShortDateString());
            TimeSpan nightRest = new TimeSpan();
            DataTable dtTime = FilterTable(TimeData, WhatDay, WhatDay.AddDays(dayRange));
            
            //1. - No posts
            if (dtTime.Rows.Count == 0)
            {
                nightRest = TimeSpan.FromHours(24 * dayRange);
            }
            //2. - One post Exists!
            if (dtTime.Rows.Count == 1)
            {
                DateTime sDate = Convert.ToDateTime(dtTime.Rows[0]["sDate"].ToString());
                DateTime eDate = Convert.ToDateTime(dtTime.Rows[0]["eDate"].ToString());
                if (sDate < DayRangeEnd && DayRangeStart <= eDate)
                {
                    TimeSpan range1 = (sDate - DayRangeStart);
                    TimeSpan range2 = (DayRangeEnd - eDate);
                    if (range1 > range2)
                    {
                        nightRest = range1;
                    }
                    else
                    {
                        nightRest = range2;
                    }
                    //Negative TimeSpans is ==> Zero
                    if(nightRest < TimeSpan.Zero)
                    {
                        nightRest = TimeSpan.FromHours(0);
                    }
                }
                else
                {
                    nightRest = TimeSpan.FromHours(24 * dayRange);
                }
            }
            //3. More then 1 post i db
            if (dtTime.Rows.Count > 1)
            {
                int i = 1;
                int RowCount = dtTime.Rows.Count;
                foreach (DataRow dr in dtTime.Rows)
                {
                    DateTime sDate = Convert.ToDateTime(dr["sdate"]);
                    DateTime eDate = Convert.ToDateTime(dr["edate"]);
                    if (sDate < DayRangeEnd && DayRangeStart <= eDate)
                    {
                        DateTime prevPostSdate = new DateTime();
                        DateTime nextPostSdate = new DateTime();
                        //1st loop
                        if (i != 1)
                        {
                            //Prev row                       
                            DataRow lastRow = dtTime.Rows[(i - 1) - 1];
                            prevPostSdate = Convert.ToDateTime(lastRow["edate"]);
                        }
                        else
                        {
                            prevPostSdate = DayRangeStart;
                        }
                        //If we are on EOF-post then dont get next post value, get instead range end value
                        if (i != RowCount)
                        {
                            //Next row
                            DataRow nextRow = dtTime.Rows[(i - 1) + 1];
                            nextPostSdate = Convert.ToDateTime(nextRow["sdate"]);
                        }
                        else
                        {
                            nextPostSdate = DayRangeEnd;
                        }
                        if (DayRangeStart < sDate && DayRangeEnd > eDate)
                        {
                            TimeSpan value1 = (sDate - prevPostSdate);
                            TimeSpan value2 = (nextPostSdate - eDate);
                            if (value1 > nightRest) nightRest = value1;
                            if (value2 > nightRest) nightRest = value2;
                        }
                        
                        if (DayRangeStart >= sDate && DayRangeEnd > eDate)
                        {
                            TimeSpan value1 = (nextPostSdate - eDate);
                            if (value1 > nightRest) nightRest = value1;
                        }
                        
                        if (DayRangeStart < sDate && DayRangeEnd <= eDate)
                        {
                            TimeSpan value1 = (sDate - prevPostSdate);
                            if (value1 > nightRest) nightRest = value1;
                        }
                        if (DayRangeStart >= sDate && DayRangeEnd <= eDate)
                        {
                            nightRest = TimeSpan.FromHours(0);
                        }                       
                    }
                    else
                    {
                        nightRest = TimeSpan.FromHours(24 * dayRange);
                    }
                    i++;
                }
            }
            return nightRest;
        }
