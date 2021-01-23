        public static bool IsNumeric(this object _obj)
        {
            if (_obj == null)
                return false;
            bool isNum;
            double retNum;
            isNum = Double.TryParse(Convert.ToString(_obj), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }
