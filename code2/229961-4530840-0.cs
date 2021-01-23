        public static bool TryParseTime(string txt, string fmt, out TimeSpan ts) {
            DateTime dt;
            bool ok = DateTime.TryParseExact(txt, fmt, null, 
                System.Globalization.DateTimeStyles.NoCurrentDateDefault, out dt);
            ts = new TimeSpan(ok ? dt.Ticks : 0);
            return ok;
        }
