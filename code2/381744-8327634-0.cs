    public static class Extensions
    {
        public static bool TryConvertToInt32(this decimal decimalValue, out int intValue)
        {
            intValue = 0;
            if ((decimalValue >= int.MinValue) && (decimalValue <= int.MaxValue))
            {
                intValue = Convert.ToInt32(decimalValue);
                return true;
            }
            return false;
        }
    }
