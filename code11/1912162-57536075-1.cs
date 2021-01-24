    public class ApiSlopeAngle
    {
        public int Year { get; set; }
        public string Month { get; set; }
        public decimal Hh { get; set; }
        public ApiSlopeAngle(int year, string month, decimal hh)
        {
            Year = year;
            Month = month;
            Hh = hh;
        }
    }
