        private static DateTime Milliseconds2Date(Double d)
        {         
            TimeSpan time = TimeSpan.FromMilliseconds(d);
            return new DateTime(1970, 1, 1) + time;
        }
        private static Double Date2Milliseconds(DateTime d)
        {
           
            var t = d.Subtract(new DateTime(1970, 1, 1));
            return t.TotalMilliseconds;            
        }
