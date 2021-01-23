    namespace MyProject.Extensions
    {
        public static class ParseEnumExtension
        {
            /// <summary>
            /// Convenience method to parse a string as an enum type
            /// </summary>
            public static T ParseEnum<T>(this string enumValue)
                where T : struct, IConvertible
            {
                return EnumParser<T>.Parse(enumValue);
            }
        }
    }
