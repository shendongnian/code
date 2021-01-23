        // accumulates an enumerable property on IConfiguration
        public static IEnumerable<TValue> GetConfigurationValues<TValue>(Func<IConfiguration, IEnumerable<TValue>> selector)
        {
            // cast included for clarification only
            return (GetMyConfigurationSources() as IEnumerable<IConfiguration>)
                .Where(c => selector(c) != null)
                .SelectMany(selector);
        }
        // accumulates a non enumerable property on IConfiguration
        public static IEnumerable<TValue> GetConfigurationValues<TValue>(Func<IConfiguration, TValue> selector)
        {
            // cast included for clarification only
            return (GetMyConfigurationSources() as IEnumerable<IConfiguration>)
                .Where(c => selector(c) != null)
                .Select(selector);
        }
        // Example usage:
        static void Main()
        {
            string[] allEnumerableValues = GetConfigurationValues(c => c.SomeEnumerableConfigPropertyOfStrings);
            string[] allNonEnumerableValues = GetConfigurationValues(c => c.SomeNonEnumerableConfigPropertyString);
        }
