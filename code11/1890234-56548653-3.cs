                Random myRand = new Random();
            bool isSatOrSun = DateTime.Now.DayOfWeek == DayOfWeek.Saturday || DateTime.Now.DayOfWeek == DayOfWeek.Sunday;
            bool isNotBetween8And1800 = DateTime.Now.Hour <= 8 || DateTime.Now.Hour >= 18;
            bool isFirstTenMinutes = DateTime.Now.Minute <= 9;
            //if you want to do Between 8 & 18 on Saturday/Sundays OR first 10 minutes of each hour on Saturday/Sunday
            while(isSatOrSun && (isNotBetween8And1800 || isFirstTenMinutes))
            {
                //do your sleep
                int waitTime = myRand.Next(120000, 180000);
                System.Threading.Thread.Sleep(waitTime);
                //now recheck your variables
                isSatOrSun = DateTime.Now.DayOfWeek == DayOfWeek.Saturday || DateTime.Now.DayOfWeek == DayOfWeek.Sunday;
                isNotBetween8And1800 = DateTime.Now.Hour <= 8 || DateTime.Now.Hour >= 18;
                isFirstTenMinutes = DateTime.Now.Minute <= 9;
            }
            //if you want to do all day on Saturday/Sundays OR Between 8 & 18 any day of the week OR  first 10 minutes of each hour any day of the week
            while (isSatOrSun || isNotBetween8And1800 || isFirstTenMinutes)
            {
                //do your sleep
                int waitTime = myRand.Next(120000, 180000);
                System.Threading.Thread.Sleep(waitTime);
                //now recheck your variables
                isSatOrSun = DateTime.Now.DayOfWeek == DayOfWeek.Saturday || DateTime.Now.DayOfWeek == DayOfWeek.Sunday;
                isNotBetween8And1800 = DateTime.Now.Hour <= 8 || DateTime.Now.Hour >= 18;
                isFirstTenMinutes = DateTime.Now.Minute <= 9;
            }
