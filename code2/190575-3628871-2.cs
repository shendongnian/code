    public class PocoValidator
    {
        public static bool ValidateProperties<TValue>(TValue value)
        {
            var type = typeof(TValue);
            var props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var prop in props)
            {
                var atts = prop.GetCustomAttributes(typeof(MaxStringLengthAttribute), true);
                var propvalue = prop.GetValue(value, null);
                // With the atts in hand, validate the propvalue ...
                // Return false if validation fails.
            }
            return true;
        }
    }
