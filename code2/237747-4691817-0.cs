        private DateTime GetTwoAm()
        {
            DateTime time1 = DateTime.Now;
            DateTime time2 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 2, 0, 0);
            if (time1 <= time2)
            {
                return time2;
            }
            else
            {
                return time2.AddDays(1);
            }
        }
