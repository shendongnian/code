    StringBuilder query = new StringBuilder("Select ID,Name ")
        DateTime begindate=DateTime.Parse("2-1-2011");
        DateTime enddate=DateTime.Parse("6-1-2011");
        DateTime tempDate = begindate;
        while(tempDate<=enddate )
        {
            if(tempDate.DayOfWeek!=DayOfWeek.Sunday)
            {
                if (tempDate==begindate )
                {
                    query.Append(",");
                }
                query.Append(","+tempDate.ToString("dd-MM-yyyy"));
            }
            tempDate = tempDate.AddDays(1);
        }
        query.Append(" From table Name");
