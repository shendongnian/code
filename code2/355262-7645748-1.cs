    class Program
    {
        static void Main(string[] args)
        {
            // Inputs as per question
            var d1 = new DateTime(2011, 1, 1);
            var d2 = new DateTime(2011, 3, 1);
            var d3 = new DateTime(2011, 4, 1);
            var d4 = new DateTime(2011, 5, 1);
            var d5 = new DateTime(2011, 6, 1);
            var d6 = new DateTime(2011, 7, 1);
            var d11 = new DateTime(2011, 9, 1);
            var d12 = new DateTime(2011, 10, 1);
            var d7 = new DateTime(2011, 2, 1);
            var d8 = d5;
            var d9 = d1;
            var d10 = new DateTime(2011, 8, 1);
            var input = new[]
            {
                new DateRange { From = d1, To = d2 },
                new DateRange { From = d3, To = d4 },
                new DateRange { From = d5, To = d6 },
                new DateRange { From = d11, To = d12 },
                new DateRange { From = d7, To = d8 },
                new DateRange { From = d9, To = d10 },
            };
