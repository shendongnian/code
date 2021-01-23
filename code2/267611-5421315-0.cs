        /// <summary>
        /// Convenience method to parse a string as an enum type
        /// </summary>
        public static T ParseEnum<T>(this string enumValue)
            where T : struct, IConvertible
        {
            return EnumUtil<T>.Parse(enumValue);
        }
    /// <summary>
    /// Utility methods for enum values. This static type will fail to initialize 
    /// (throwing a <see cref="TypeInitializationException"/>) if
    /// you try to provide a value that is not an enum.
    /// </summary>
    /// <typeparam name="T">An enum type. </typeparam>
    public static class EnumUtil<T>
        where T : struct, IConvertible // Try to get as much of a static check as we can.
    {
        // The .NET framework doesn't provide a compile-checked
        // way to ensure that a type is an enum, so we have to check when the type
        // is statically invoked.
        static EnumUtil()
        {
            // Throw Exception on static initialization if the given type isn't an enum.
            Require.That(typeof (T).IsEnum, () => typeof(T).FullName + " is not an enum type.");
        }
        public static T Parse(string enumValue)
        {
            var parsedValue = (T)System.Enum.Parse(typeof (T), enumValue);
            //Require that the parsed value is defined
            Require.That(parsedValue.IsDefined(), 
                () => new ArgumentException(string.Format("{0} is not a defined value for enum type {1}", 
                    enumValue, typeof(T).FullName)));
            return parsedValue;
        }
        public static bool IsDefined(T enumValue)
        {
            return System.Enum.IsDefined(typeof (T), enumValue);
        }
    }
