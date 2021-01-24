    class Program
    {
        static void Main()
        {
            DateTime?[] dates = new DateTime?[]
            {
                new DateTime(2019,1,1),
                null,
                new DateTime(2019,1,3),
                null, null,
                new DateTime(2019,1,6),
                null,null,null,
                new DateTime(2019,1,10),
                null,null,null, null,null,null, null,null,null,
                new DateTime(2019,1,20),
            };
            Console.WriteLine("Before:");
            foreach (var zeit in dates)
                if (zeit != null)
                    Console.WriteLine(zeit);
                else
                    Console.WriteLine("<empty>");
            interpolate_dates(dates);
            Console.WriteLine("\nAfter:");
            foreach (var zeit in dates)
                if (zeit != null)
                    Console.WriteLine(zeit);
                else
                    Console.WriteLine("!!ERROR!! - all dates should be interpolated.");
        }
        static public void interpolate_dates(Span<DateTime?> dates)
        {
            if (dates.Length == 0)
                return;
            if (!dates[0].HasValue)
                throw new ArgumentException("First date cannot be null.");
            int last_filled_date_index = 0;
            for (int checking_index = 1; checking_index < dates.Length; checking_index++)
            {
                if (dates[checking_index].HasValue)
                {
                    if (checking_index != last_filled_date_index + 1)
                    {
                        interpolate(dates, last_filled_date_index, checking_index);
                    }
                    last_filled_date_index = checking_index;
                }
            }
            if (last_filled_date_index > 0 && !dates[dates.Length - 1].HasValue)
                throw new ArgumentException("Last date value cannot be null");
        }
        static public void interpolate(Span<DateTime?> dates, int earlier_date_idx, int later_date_idx)
        {
            TimeSpan interval = (dates[later_date_idx].Value - dates[earlier_date_idx].Value) / (later_date_idx - earlier_date_idx);
            for (int index = earlier_date_idx+1; index < later_date_idx; index++)
            {
                    dates[index] = dates[index -1] + interval;
            }
        }
    }
