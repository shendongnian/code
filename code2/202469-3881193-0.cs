        using System;
        using System.Diagnostics;
        using System.Globalization;
        using System.Text;
        /// <summary>
        /// Provides extension methods for strings.
        /// </summary>
        public static class StringExtensions
        {
            #region Methods
            /// <summary>
            /// Converts the specified string to a <see cref="Boolean"/>
            /// </summary>
            /// <param name="string">The string to convert.</param>
            /// <returns>The specified string as a <see cref="Boolean"/>.</returns>
            public static bool AsBoolean(this string @string)
            {
                return bool.Parse(@string);
            }
            /// <summary>
            /// Converts the specified string to a <see cref="Boolean"/> using TryParse.
            /// </summary>
            /// <remarks>
            /// If the specified string cannot be parsed, the default value (if valid) or false is returned.
            /// </remarks>
            /// <param name="string">The string to convert.</param>
            /// <param name="default">The default value for if the value cannot be parsed.</param>
            /// <returns>The specified string as a <see cref="DateTime"/>.</returns>
            public static bool AsBooleanNonStrict(this string @string, bool? @default = null)
            {
                bool @bool;
                if ((!string.IsNullOrEmpty(@string)) && bool.TryParse(@string, out @bool))
                    return @bool;
                if (@default.HasValue)
                    return @default.Value;
                return false;
            }
            /// <summary>
            /// Converts the specified string to a <see cref="DateTime"/>
            /// </summary>
            /// <param name="string">The string to convert.</param>
            /// <returns>The specified string as a <see cref="DateTime"/>.</returns>
            public static DateTime AsDateTime(this string @string)
            {
                return DateTime.Parse(@string);
            }
            /// <summary>
            /// Converts the specified string to a <see cref="DateTime"/> using TryParse.
            /// </summary>
            /// <remarks>
            /// If the specified string cannot be parsed, <see cref="DateTime.MinValue"/> is returned.
            /// </remarks>
            /// <param name="string">The string to convert.</param>
            /// <param name="default">The default value for if the value cannot be parsed.</param>
            /// <returns>The specified string as a <see cref="DateTime"/>.</returns>
            public static DateTime AsDateTimeNonStrict(this string @string, DateTime? @default = null)
            {
                DateTime datetime;
                if ((!string.IsNullOrEmpty(@string)) && DateTime.TryParse(@string, out datetime))
                    return datetime;
                if (@default.HasValue)
                    return @default.Value;
                return DateTime.MinValue;
            }
            /// <summary>
            /// Converts the specified string to a <see cref="TEnum"/>
            /// </summary>
            /// <param name="string">The string to convert.</param>
            /// <returns>The specified string as a <see cref="TEnum"/>.</returns>
            public static TEnum AsEnum<TEnum>(this string @string) where TEnum : struct
            {
                return (TEnum)Enum.Parse(typeof(TEnum), @string);
            }
            /// <summary>
            /// Converts the specified string to a <see cref="TEnum"/>
            /// </summary>
            /// <param name="string">The string to convert.</param>
            /// <returns>The specified string as a <see cref="TEnum"/>.</returns>
            public static TEnum AsEnumNonStrict<TEnum>(this string @string, TEnum @default) where TEnum : struct
            {
                TEnum @enum;
                if ((!string.IsNullOrEmpty(@string)) && Enum.TryParse(@string, out @enum))
                    return @enum;
                return @default;
            }
            /// <summary>
            /// Converts the specified string to a <see cref="Int32"/>
            /// </summary>
            /// <param name="string">The string to convert.</param>
            /// <returns>The specified string as a <see cref="Int32"/>.</returns>
            public static int AsInteger(this string @string)
            {
                return int.Parse(@string);
            }
            /// <summary>
            /// Converts the specified string to a <see cref="Int32"/> using TryParse.
            /// </summary>
            /// <remarks>
            /// If the specified string cannot be parsed, the default value (if valid) or 0 is returned.
            /// </remarks>
            /// <param name="string">The string to convert.</param>
            /// <param name="default">The default value for if the value cannot be parsed.</param>
            /// <returns>The specified string as a <see cref="Int32"/>.</returns>
            public static int AsIntegerNonStrict(this string @string, int? @default = null)
            {
                int @int;
                if ((!string.IsNullOrEmpty(@string)) && int.TryParse(@string, out @int))
                    return @int;
                if (@default.HasValue)
                    return @default.Value;
                return 0;
            }
            /// <summary>
            /// Converts the specified string to a <see cref="bool"/>
            /// </summary>
            /// <param name="string">The string to convert.</param>
            /// <returns>The specified string as a <see cref="DateTime"/>.</returns>
            public static bool? AsNullableBolean(this string @string)
            {
                bool @bool;
                if ((string.IsNullOrEmpty(@string)) || !bool.TryParse(@string, out @bool))
                    return null;
                return @bool;
            }
            /// <summary>
            /// Converts the specified string to a <see cref="DateTime"/>
            /// </summary>
            /// <param name="string">The string to convert.</param>
            /// <returns>The specified string as a <see cref="DateTime"/>.</returns>
            public static DateTime? AsNullableDateTime(this string @string)
            {
                DateTime dateTime;
                if ((string.IsNullOrEmpty(@string)) || !DateTime.TryParse(@string, out dateTime))
                    return null;
                return dateTime;
            }
            /// <summary>
            /// Converts the specified string to a <see cref="DateTime"/>
            /// </summary>
            /// <param name="string">The string to convert.</param>
            /// <returns>The specified string as a <see cref="DateTime"/>.</returns>
            public static TEnum? AsNullableEnum<TEnum>(this string @string) where TEnum : struct
            {
                TEnum @enum;
                if ((string.IsNullOrEmpty(@string)) || !Enum.TryParse(@string, out @enum))
                    return null;
                return @enum;
            }
            /// <summary>
            /// Converts the specified string to a <see cref="Int32"/>
            /// </summary>
            /// <param name="string">The string to convert.</param>
            /// <returns>The specified string as a <see cref="Int32"/>.</returns>
            public static int? AsNullableInteger(this string @string)
            {
                int @int;
                if ((string.IsNullOrEmpty(@string)) || !int.TryParse(@string, out @int))
                    return null;
                return @int;
            }
            #endregion
        }
