    public List<DateTime> CreateDateList(DateTime inputDate)
    { 
        List<DateTime> mondayList = new List<DateTime>();
        while(inputDate.DayOfWeek != DayOfWeek.Monday)
        {
            mondayList.Add(inputDate);
            inputDate = inputDate.AddDays(-1);
        }
        return mondayList;
    }
