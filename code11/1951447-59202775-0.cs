            var myDate = new DateTimeOffset(2019, 12, 05, 13, 20, 15, 478, new TimeSpan(0, 2, 0, 0, 0));
            var now = new DateTimeOffset(2019, 12, 05, 14, 20, 45, 478, new TimeSpan(0, 3, 0, 0, 0));
            var span = now.Subtract(myDate);
            int expMin = 1;
            if (span.Minutes < expMin)
            {
                Console.WriteLine("Do something");
            }
            else
            {
                Console.WriteLine("Ignore");
            }
