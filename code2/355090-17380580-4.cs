        public static string GetTimeStamp() 
        {
            Func<DateTime, string> f = dt => humanReadable 
                                           ? dt.ToShortTimeString() 
                                           : dt.ToLongTimeString();
            return f(DateTime.Now);
        }
