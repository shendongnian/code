        public static bool IsDateMultipleDays(DateTime originalDate, int numberOfDays, DateTime potentialDate)
        {
            var original = originalDate.Date; // to make sure that it doesn't have a time portion
            var potential = potentialDate.Date;
            var difference = potential - original;
            return (int)difference.TotalDays % numberOfDays == 0;
        }
