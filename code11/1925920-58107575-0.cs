    public class AmountPerMonth
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public decimal Amount { get; set; }
        public static List<AmountPerMonth> FromPeriod(AmountPerPeriod period)
        {
            var amtPerDay = period.Amount / ((period.EndDate - period.StartDate).Days + 1);
            var result = new List<AmountPerMonth>();
            for (var date = period.StartDate; date <= period.EndDate; 
                 date = date.AddMonths(1).ToFirstDateOfMonth())
            {
                var lastDayOfMonth = date.ToLastDateOfMonth();
                var lastDay = period.EndDate < lastDayOfMonth
                    ? period.EndDate
                    : lastDayOfMonth;
                var amount = ((lastDay - date).Days + 1) * amtPerDay;
                result.Add(new AmountPerMonth
                {
                    Id = period.Id,
                    Year = date.Year,
                    Month = date.Month,
                    Amount = amount
                });
            }
            return result;
        }
        public override string ToString()
        {
            return $"{Id,-3} |{Month,-6}| {Year,-6}| {Amount:0.00}";
        }
    }
