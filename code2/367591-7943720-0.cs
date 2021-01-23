    public class Program
    {
        static void Main(string[] args)
        {
            TestDateRange(DateTime.Today, DateTime.Today.AddMonths(1));
        }
        Dictionary<DateTime, List<string>> bookings;
        int maxOccupancy = 2;
        public Program(int year = 2011)
        {
            bookings = getDateRange(new DateTime(year, 1, 1), new DateTime(year,12,31)).ToDictionary(day => day, day => new List<string>());
        }
        private static void TestDateRange(DateTime startDate, DateTime endDate)
        {
            Program p = new Program();
            if (p.GetFullDaysInDateRange(startDate, endDate).Count() == 0)
            {
                string bookingName = "Booking for test";
                p.AddBooking(startDate, endDate, bookingName);
            }
        }
        private IEnumerable<DateTime> getDateRange(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
            {
                return null;
            }
            return Enumerable.Range((int)startDate.ToOADate(), endDate.Subtract(startDate).Days).Select(day => DateTime.FromOADate(day));
        }
        private void AddBooking(DateTime startDate, DateTime endDate, string name)
        {
            IEnumerable<DateTime> range = getDateRange(startDate, endDate);
            foreach (DateTime date in range)
            {
                if (bookings[date].Contains(name))
                    return; //already placed this booking
                if (bookings[date].Count > maxOccupancy)
                    throw new Exception(String.Format("Cannot book on {0}: full", date));
                bookings[date].Add(name);
            }
        }
        public IEnumerable<DateTime> GetFullDaysInDateRange(DateTime startDate, DateTime endDate)
        {
            IEnumerable<DateTime> testRange = getDateRange(startDate, endDate);
            List<DateTime> bookedDays = new List<DateTime>();
            foreach (DateTime date in testRange)
            {
                if (bookings[date].Count > maxOccupancy)
                    bookedDays.Add(date);
            }
            return bookedDays;
        }
    }
