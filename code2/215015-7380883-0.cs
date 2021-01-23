        public static IEnumerable<TEnum> GetFlags<TEnum>(this TEnum input, bool checkZero = false, bool checkFlags = true, bool checkCombinators = true)
        {
            Type enumType = typeof(TEnum);
            if (!enumType.IsEnum)
                yield break;
            ulong setBits = Convert.ToUInt64(input);
            // if no flags are set, return empty
            if (!checkZero && (0 == setBits))
                yield break;
            // if it's not a flag enum, return empty
            if (checkFlags && !input.GetType().IsDefined(typeof(FlagsAttribute), false))
                yield break;
            if (checkCombinators)
            {
                // check each enum value mask if it is in input bits
                foreach (TEnum value in Enum<TEnum>.GetValues())
                {
                    ulong valMask = Convert.ToUInt64(value);
                    if ((setBits & valMask) == valMask)
                        yield return value;
                }
            }
            else
            {
                // check each enum value mask if it is in input bits
                foreach (TEnum value in Enum <TEnum>.GetValues())
                {
                    ulong valMask = Convert.ToUInt64(value);
                    if ((setBits & valMask) == valMask)
                        yield return value;
                }
            }
        }
