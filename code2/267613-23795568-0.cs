    namespace MyProject.Helpers
    {
        /// <summary>
        /// Utility methods for enum values. This static type will fail to initialize 
        /// (throwing a <see cref="TypeInitializationException"/>) if
        /// you try to provide a value that is not an enum.
        /// </summary>
        /// <typeparam name="T">An enum type. </typeparam>
        public static class EnumParser<T>
            where T : struct, IConvertible // Try to get as much of a static check as we can.
        {
            // The .NET framework doesn't provide a compile-checked
            // way to ensure that a type is an enum, so we have to check when the type
            // is statically invoked.
            static EnumParser()
            {
                // Throw Exception on static initialization if the given type isn't an enum.
                if (!typeof (T).IsEnum)
                    throw new Exception(typeof(T).FullName + " is not an enum type.");
            }
    
            public static T Parse(string enumValue)
            {
                var parsedValue = (T)Enum.Parse(typeof (T), enumValue);
                //Require that the parsed value is defined
                if (!IsDefined(parsedValue))
                    throw new ArgumentException(string.Format("{0} is not a defined value for enum type {1}", 
                        enumValue, typeof(T).FullName));
    
                return parsedValue;
            }
    
            public static bool IsDefined(T enumValue)
            {
                return Enum.IsDefined(typeof (T), enumValue);
            }
        }
    }
