        static public DateTime todate(string t)
        {
            t = t.Replace("h", ":");
            t = t.Replace("m", ":");
            t = t.Replace("s", "");
            return DateTime.Parse(t);
        }
