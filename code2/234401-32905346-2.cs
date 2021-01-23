    public static class DateTimeExtensions
    {
        public static double TotalMonthsDifference(this DateTime from, DateTime to)
        {
            //Compute full months difference between dates
            var fullMonthsDiff = (to.Year - from.Year)*12 + to.Month - from.Month;
            //Compute difference between the % of day to full days of each month
            var fractionMonthsDiff = ((double)(to.Day-1) / (DateTime.DaysInMonth(to.Year, to.Month)-1)) -
                ((double)(from.Day-1)/ (DateTime.DaysInMonth(from.Year, from.Month)-1));
            return fullMonthsDiff + fractionMonthsDiff;
        }
    }
