        public static string StrFromDB(object theValue)
        {
            return StrFromDB(theValue, "");
        }
        public static string StrFromDB(object theValue, string sDefaultValue)
        {
            if ((theValue != DBNull.Value) && (theValue != null))
            {
                return theValue.ToString();
            }
            else
            {
                return sDefaultValue;
            }
        }
        public static bool BoolFromDB(object theValue)
        {
            return BoolFromDB(theValue, false);
        }
        public static bool BoolFromDB(object theValue, bool fDefaultValue)
        {
            if (!(string.IsNullOrEmpty(StrFromDB(theValue))))
            {
                return Convert.ToBoolean(theValue);
            }
            else
            {
                return fDefaultValue;
            }
        }
        public static int IntFromDB(object theValue)
        {
            return IntFromDB(theValue, 0);
        }
        public static int IntFromDB(object theValue, int wDefaultValue)
        {
            if ((theValue != DBNull.Value) && (theValue != null) && IsNumeric(theValue))
            {
                return Convert.ToInt32(theValue);
            }
            else
            {
                return wDefaultValue;
            }
        }
