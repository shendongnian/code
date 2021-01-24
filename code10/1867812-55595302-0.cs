                DateTime startDate = DateTime.Parse("2/10/17");
                DateTime endDate = DateTime.Now;
                DateTime previousQuarter = new DateTime(
                    startDate.Year, (4 * (startDate.Month / 4)) + 1, 1);
                List<DateTime> quarters = new List<DateTime>();
                DateTime quarter = previousQuarter;
                while (quarter < endDate)
                {
                    quarter = quarter.AddMonths(3);
                    quarters.Add(quarter);
                }
