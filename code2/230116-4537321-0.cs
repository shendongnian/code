            DateTime d1 = new DateTime(2011, 12, 27, 4, 37, 17);
            DateTime d2 = DateTime.Now;
            if (d1.Subtract(d2).Seconds <= 1)
            {
                //consider these DateTimes equal... continue
            }
