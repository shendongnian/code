        /// <summary>
        /// Helper method to try to convert a value to an enumeration value.
        /// 
        /// If <paramref name="value"/> is not convertable to <typeparam name="TEnum"/>, an exception will be thrown
        /// as documented by Convert.ChangeType.
        /// </summary>
        /// <param name="value">The value to convert to the enumeration type.</param>
        /// <param name="outEnum">The enumeration type value.</param>
        /// <returns>true if value was successfully converted; false otherwise.</returns>
        /// <exception cref="InvalidOperationException">Thrown if <typeparamref name="TEnum"/> is not an enum type. (Because we can't specify a generic constraint that T is an Enum.)</exception>
        public static bool TryAsEnum<TValue, TEnum>( TValue value, out TEnum outEnum ) where TEnum : struct
        {
            var enumType = typeof( TEnum );
            if ( !enumType.IsEnum )
            {
                throw new InvalidOperationException( string.Format( "{0} is not an enum type.", enumType.Name ) );
            }
            var valueAsUnderlyingType = Convert.ChangeType( value, Enum.GetUnderlyingType( enumType ) );
            
            if ( Enum.IsDefined( enumType, valueAsUnderlyingType ) )
            {
                outEnum = (TEnum) Enum.ToObject( enumType, valueAsUnderlyingType );
                return true;
            }
            // IsDefined returns false if the value is multiple composed flags, so detect and handle that case
            if( enumType.GetCustomAttributes( typeof( FlagsAttribute ), inherit: true ).Any() )
            {
                // Flags attribute set on the enum. Get the enum value.
                var enumValue = (TEnum)Enum.ToObject( enumType, valueAsUnderlyingType );
                // If a value outside the actual enum range is set, then ToString will result in a numeric representation (rather than a string one).
                // So if a number CANNOT be parsed from the ToString result, we know that only defined values have been set.
                decimal parseResult;
                if( !decimal.TryParse( enumValue.ToString(), out parseResult ) )
                {
                    outEnum = enumValue;
                    return true;
                }
            }
            outEnum = default( TEnum );
            return false;
        }
