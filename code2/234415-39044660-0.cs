        public static int GetMonthsDiff(DateTime start, DateTime end)
        {
            if (start > end)
                return GetMonthsDiff(end, start);
            int months = 0;
            do
            {
                start = start.AddMonths(1);
                if (start > end)
                    return months;
                months++;
            }
            while (true);
        }
