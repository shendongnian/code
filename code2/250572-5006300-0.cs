    DateTime dt1 = new DateTime(2010, 10, 1, 16, 0, 0);
    DateTime dt2 = new DateTime(2010, 10, 2, 10, 0, 0);
    int hours = Enumerable.Range(1, (dt2 - dt1).Hours)
                     .Where(h =>
                        {
                            var dt = dt1.AddHours(h);
                            return dt.DayOfWeek != DayOfWeek.Saturday
                                   && dt.DayOfWeek != DayOfWeek.Sunday
                                   && dt.Hour >= 9 && dt.Hour <= 17;
                        }).Count();
