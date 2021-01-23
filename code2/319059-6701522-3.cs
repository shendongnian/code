    /// <summary>
    /// Provides conversion between long integers and custom number bases.
    /// </summary>
    public class BaseConverter
    {
        private string _characterSet;
    
        /// <summary>
        /// Creates a new BaseConverter.
        /// </summary>
        /// <param name="characterSet">The characters in the custom base, in  
        /// increasing order of value.</param>
        public BaseConverter(string characterSet = 
           "0123456789abcdefghijklmnopqrstuvwxyz")
        {
            _characterSet = characterSet;
        }
    
        /// <summary>
        /// Converts a number in the custom base system to a long.
        /// </summary>
        /// <param name="value">The custom base number to convert.</param>
        /// <returns>The long form of the custom base number.</returns>
        public long StringToLong(string value)
        {
            if (value == Convert.ToString(_characterSet[0])) return 0;
            long val = 0; 
            string text = value[0] == '-' ? value.Substring(1, 
               value.Length - 1) : value;
    
            for (int i = text.Length, power = 0; i != 0; i--, power++)
            {
                val += (long)Math.Round((_characterSet.IndexOf(text[i-1]) * 
                   Math.Pow(_characterSet.Length, power)));
            }
    
            return value[0] == '-' ? -val : val;
        }
    
        /// <summary>
        /// Converts a long to the custom base system.
        /// </summary>
        /// <param name="value">The long to convert.</param>
        /// <returns>The custome base number version of the long.</returns>
        public string LongToString(long value)
        {
            if (value == 0) return Convert.ToString(_characterSet[0]);
            long number = value.Abs();
            int remainder;
            StringBuilder text = new StringBuilder((int)Math.Round(
               Math.Log(long.MaxValue, (double)_characterSet.Length)) + 
               value < 0 ? 1 : 0);
    
            while (number != 0)
            {
                remainder = (int)(number % _characterSet.Length);
                text.Insert(0, _characterSet[remainder]);
                number -= remainder;
                number /= _characterSet.Length;
            }
    
            if (value < 0) text.Insert(0, "-");
            return text.ToString();
        }
