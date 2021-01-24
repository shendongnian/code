                DateTime[] dates = new  DateTime[] { 
                    DateTime.Parse("06-07-2019 10:00AM"),
                    DateTime.Parse("06-07-2019 11:00AM"),
                    DateTime.Parse("05-07-2019 10:00 pm")
                };
                DateTime[] orderDates = dates
                    .OrderByDescending(x => x.Date)
                    .GroupBy(x => x.Date)
                    .SelectMany(x => x.OrderBy(y => y.TimeOfDay))
                    .ToArray();
