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
        /// <summary>
        /// In the .NET Framework, objects can be cast to enum values which are not
        /// defined for their type. This method provides a simple fail-fast check
        /// that the enum value is defined, and creates a cast at the same time.
        /// Cast the given value as the given enum type.
        /// Throw an exception if the value is not defined for the given enum type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumValue"></param>
        /// <exception cref="InvalidCastException">
        /// If the given value is not a defined value of the enum type.
        /// </exception>
        /// <returns></returns>
        public static T DefinedCast(object enumValue)
        {
            if (!System.Enum.IsDefined(typeof(T), enumValue))
                throw new InvalidCastException(enumValue + " is not a defined value for enum type " +
                                               typeof (T).FullName);
            return (T) enumValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="enumValue"></param>
        /// <returns></returns>
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
