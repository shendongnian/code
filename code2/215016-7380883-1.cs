    public static class Enum<TEnum>
    {
        public static TEnum Parse(string value)
        {
            return (TEnum)Enum.Parse(typeof(TEnum), value);
        }
        public static IEnumerable<TEnum> GetValues()   
        {
            foreach (object value in Enum.GetValues(typeof(TEnum)))
                yield return ((TEnum)value);
        }
    }  
  
