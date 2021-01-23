    namespace DecimalSplit
    {
        class Program
        {
            static void Main(string[] args)
            {
                double value = 2635.215;
                var values = value.ToString(CultureInfo.InvariantCulture).Split('.');
                int firstValue = int.Parse(values[0]);
                int secondValue = int.Parse(values[1]);
            }
        }
    }
