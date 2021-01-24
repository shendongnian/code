    static class InfoExtensions
    {
        public static DateTime StartDateTime(this Info info)
        {
            return info.startTime.ToDateTime();
        }
        public static DateTime EndDateTime(this Info info)
        {
            return info.endTime.ToDateTime();
        }
        private static DateTime ToDateTime(this string date3rdParty)
        {
             // ask from your 3rd party what the value means
            // for instance: seconds since some start epoch time:
            static DateTime epochTime = new DateTime(...)
            double secondsSinceEpochTime = Double.Parse(date3rdParty);
            return epochTime.AddSeconds(secondsSinceEpochTime);
        }
    }
