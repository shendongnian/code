    class Program
      {
        static void Main(string[] args)
        {
          decimal? value = CustomParse("3,000,000");
          Console.WriteLine(value);
        }
    
        public static decimal? CustomParse(string incomingValue)
        {
          decimal val;
          if (!decimal.TryParse(incomingValue.Replace(",", ""), NumberStyles.Number, CultureInfo.InvariantCulture, out val))
            return null;
          return val;
        }
      }
