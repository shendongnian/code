    private static bool IsInRunHours()
    {
            try
            {
                ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
                // after = 18 before = 5
                // Only take the current time once; otherwise you could get into a mess if it
                // changes day between samples.
                DateTime now = DateTime.Now;
                DateTime today = now.Date;
               Int32 startHour = ConfigurationManager.AppSettings["UpdateRunAfter"].ToInt();
                Int32 stopHour = ConfigurationManager.AppSettings["UpdateRunBefore"].ToInt(); 
                DateTime start = today.AddHours(startHour);
                DateTime end = today.AddHours(stopHour);
                if (stopHour < startHour)
                {
                     end = today.AddHours(stopHour+24);
                }
                //ConfigurationManager.AppSettings["UpdateRunBefore"].ToInt()
                //ConfigurationManager.AppSettings["UpdateRunAfter"].ToInt()
                // Cope with a start hour later than an end hour - we just
                // want to invert the normal result.
                bool invertResult = end < start;
                // Now check for the current time within the time period
                bool inRange = (start <= now && now <= end) ^ invertResult;
                if (inRange)
                {
                    return true;
                }
                else
                {
                    return false;
                }
             
            }
            catch
            {
                return false;
            }
        }
