        static DateTime EPOCH = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
        public static double ConvertDatetimeToUnixTimeStamp(DateTime date , int Time_Zone = 0)
        {
            TimeSpan The_Date = (date - EPOCH);
            return Math.Floor(The_Date.TotalSeconds) - (Time_Zone * 3600);
        }
