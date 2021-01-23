    public static int IntegerDate(DateTime date)
        {
            int Month = date.Month;
            int Day = date.Day;
            int Year = date.Year;
            if (Month < 3)
            {
                Month = Month + 12;
                Year = Year - 1;
            }
            //modified Julian Date
            return Day + (153 * Month - 457) / 5 + 365 * Year + (Year / 4) - (Year / 100) + (Year / 400) - 678882;
        }
