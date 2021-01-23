        public static DateTime? ConvertFromOracleDate(object oracleDate)
        {
            if (oracleDate == null)
                throw new ArgumentNullException("oracleDate");
            if (!(oracleDate is string))
                throw new ArgumentException("oracleDate");  
            var sDate = (string) oracleDate;
            if (sDate.Equals(String.Empty))
                return null;
            if (sDate.Length != 8)
                throw new ArgumentOutOfRangeException("oracleDate");
            
            sDate = sDate.Insert(6, "/");
            sDate = sDate.Insert(4, "/");
            var ci = new CultureInfo("en-US");
            
            return Convert.ToDateTime(sDate, ci);
        }
