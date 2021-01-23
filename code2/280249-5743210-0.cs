    class DateTimeQuarter
    {
        public DateTimeQuarter(DateTime date)
        {
            Date = date;
            Quarter = date.Month / 4 + 1;
        }
        public static int operator -(DateTimeQuarter lhs, DateTimeQuarter rhs)
        {
            double value = Convert.ToDouble(
                (rhs.Date.Year - lhs.Date.Year)) + (rhs.Quarter / 10.0) - (rhs.Quarter / 10.0);
            int result = 
                (Convert.ToInt32(value) * 4) + Convert.ToInt32(value - Math.Floor(value));
            return result;
        }
        public DateTime Date { get; set; }
        public int Quarter { get; set; }
    }
    
    static void Main(string[] args)
    {
        DateTimeQuarter q1 = new DateTimeQuarter(new DateTime(2006, 04, 20));
        DateTimeQuarter q2 = new DateTimeQuarter(new DateTime(2007, 12, 25));
    
        int quarters = q1 - q2;
    }
