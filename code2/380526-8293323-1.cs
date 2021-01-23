            var date = new DateTime(2011, 1, 1);
            while (date < new DateTime(2012, 1, 1))
            {
                Console.WriteLine(loc + date.ToString("ddMM")); // ddMM stands for day-day, Month-Month (indicating you want them both displayed in a double digit format)
                date = date.AddDays(1);
            }
