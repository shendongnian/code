    public static DateTime getFirstMondayOfMonthAndYear(int Month, int Year)
    {
        DateTime dt;
        DateTime.TryParse(String.Format("{0}/{1}/1", Year, Month), out dt); 
        for (int i = 0; i < 7; i++)
			{
            if (dt.DayOfWeek == DayOfWeek.Monday)
            {
                return dt;
            }
            else
            {
                dt = dt.AddDays(1);
            }
			}
        // If get to here, punt
        return DateTime.Now;
    }
