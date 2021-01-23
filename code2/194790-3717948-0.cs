    public static class DateTimeExtensions
    {
        public static DateTime AddWorkingDays(this DateTime self, int days)
        {
            self = self.AddDays(days);
            while (self.DayOfWeek == DayOfWeek.Saturday || self.DayOfWeek == DayOfWeek.Sunday)
            {
                self = self.AddDays(1);
            }
    
            return self;
        }
    }
