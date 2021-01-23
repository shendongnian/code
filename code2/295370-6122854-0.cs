    public class TemperatureConverter
    {
        private static readonly IDictionary<Tuple<string, string>, Func<double, double>> ConverterMap =
            new Dictionary<Tuple<string, string>, Func<double, double>>
            {
                { Tuple.Create("celsius", "kelvin"), t => t + 273 },
                // add similar lines to convert from/to other measurements
            }
    
        public static double Convert(double degrees, string fromType, string toType)
        {
            fromType = fromType.ToLowerInvariant();
            toType = toType.ToLowerInvariant();
            if (fromType == toType) {
                return degrees; // no conversion necessary
            }
    
            return ConverterMap[Tuple.Create(fromType, toType)](degrees);
        }
    }
