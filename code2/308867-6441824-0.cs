    public static class StringExt 
    {
        public static DateTime ParseToDateTimeMyWay(this string iString)
        {
            DateTime dt;
            DateTime.TryParseExact(iString, "dd/MM/yyyy", System.Threading.Thread.CurrentThread.CurrentCulture, System.Globalization.DateTimeStyles.None, out dt);
            return dt;
        }
    }
    "04/15/1981".ParseToDateTimeMyWay(); 
