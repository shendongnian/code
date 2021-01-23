        public static IList<DatesBag> GetDateInfo(DateTime givenDate, int numberOfWeeks)
        {
            var result = new List<DatesBag>();
            for (int i = 0; i < numberOfWeeks; i++)
            {
                int firstWeekDay = Week.GetFirstDayOfWeek(givenDate).Day;
                result.Add(new DatesBag
                   {
                       Week = (WeeksOfAMonth) ((firstWeekDay / 7) + ((firstWeekDay % 7 == 0) ? 0 : 1)),
                       FirstDayOfWeek = Week.GetFirstDayOfWeek(givenDate),
                       LastDayOfWeek = Week.GetLastDayOfWeek(givenDate)
                   });
                givenDate = givenDate.AddDays(7);
            }
            return result;
        }
