    static void Main(string[] args) {
            DateTime EndDate = new DateTime(1973, 4, 28);
            DateTime BeginDate = new DateTime(1972, 2, 29);
            int years, months, days;
            GetYearsMonthsDays(EndDate, BeginDate, out years, out months, out days);
            Console.WriteLine($"{years} year(s), {months} month(s) and {days} day(s)");
        }
        /// <summary>
        /// Calculates how many years, months and days are between two dates.
        /// </summary>
        /// <remarks>
        /// The fundamental idea here is that most of the time all of us agree
        /// that a month has passed today since the same day of the previous month.
        /// A particular case is when both days are the last days of their respective months 
        /// when again we can say one month has passed.
        /// In the following cases the idea of a month is a moving target.
        /// - When only the beginning date is the last day of the month then we're left just with 
        /// a number of days from the next month equal to the day of the month that end date represent
        /// - When only the end date is the last day of its respective month we clearly have a 
        /// whole month plus a few days after the the day of the beginning date until the end of its
        /// respective months
        /// In all the other cases we'll check
        /// - beginingDay > endDay -> less then a month just daysToEndofBeginingMonth + dayofTheEndMonth
        /// - beginingDay < endDay -> full month + (endDay - beginingDay)
        /// - beginingDay == endDay -> one full month 0 days
        /// 
        /// </remarks>
        /// 
        private static void GetYearsMonthsDays(DateTime EndDate, DateTime BeginDate, out int years, out int months, out int days ) {
            var beginMonthDays = DateTime.DaysInMonth(BeginDate.Year, BeginDate.Month);
            var endMonthDays = DateTime.DaysInMonth(EndDate.Year, EndDate.Month);
            // get the full years
            years = EndDate.Year - BeginDate.Year - 1;
            // how many full months in the first year
            var firstYearMonths = 12 - BeginDate.Month;
            // how many full months in the last year
            var endYearMonths = EndDate.Month - 1;
            // full months
            months = firstYearMonths + endYearMonths;           
            days = 0;
            // Particular end of month cases
            if(beginMonthDays == BeginDate.Day && endMonthDays == EndDate.Day) {
                months++;
            }
            else if(beginMonthDays == BeginDate.Day) {
                days += EndDate.Day;
            }
            else if(endMonthDays == EndDate.Day) {
                days += beginMonthDays - BeginDate.Day;
            }
            // For all the other cases
            else if(EndDate.Day > BeginDate.Day) {
                months++;
                days += EndDate.Day - BeginDate.Day;
            }
            else if(EndDate.Day < BeginDate.Day) {                
                days += beginMonthDays - BeginDate.Day;
                days += EndDate.Day;
            }
            else {
                months++;
            }
            if(months >= 12) {
                years++;
                months = months - 12;
            }
        }
