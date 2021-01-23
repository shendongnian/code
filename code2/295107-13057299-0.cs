        public IEnumerable<TEnum> AllCombinations<TEnum>() where TEnum : struct
        {
            Type enumType = typeof (TEnum);
            if (!enumType.IsEnum)
                throw new ArgumentException(string.Format("The type {0} does not represent an enumeration.", enumType), "TEnum");
            if (enumType.GetCustomAttributes(typeof (FlagsAttribute), true).Length > 0) //Has Flags attribute
            {
                var allCombinations = new HashSet<TEnum>();
                var underlyingType = Enum.GetUnderlyingType(enumType);
                if (underlyingType == typeof (sbyte) || underlyingType == typeof (short) || underlyingType == typeof (int) || underlyingType == typeof (long))
                {
                    long[] enumValues = Array.ConvertAll((TEnum[]) Enum.GetValues(enumType), value => Convert.ToInt64(value));
                    for (int i = 0; i < enumValues.Length; i++)
                        FillCombinationsRecursive(enumValues[i], i + 1, enumValues, allCombinations);
                }
                else if (underlyingType == typeof (byte) || underlyingType == typeof (ushort) || underlyingType == typeof (uint) || underlyingType == typeof (ulong))
                {
                    ulong[] enumValues = Array.ConvertAll((TEnum[]) Enum.GetValues(enumType), value => Convert.ToUInt64(value));
                    for (int i = 0; i < enumValues.Length; i++)
                        FillCombinationsRecursive(enumValues[i], i + 1, enumValues, allCombinations);
                }
                return allCombinations;
            }
            //No Flags attribute
            return (TEnum[]) Enum.GetValues(enumType);
        }
        private void FillCombinationsRecursive<TEnum>(long combination, int start, long[] initialValues, HashSet<TEnum> combinations) where TEnum : struct
        {
            combinations.Add((TEnum)Enum.ToObject(typeof(TEnum), combination));
            if (combination == 0)
                return;
            for (int i = start; i < initialValues.Length; i++)
            {
                var nextCombination = combination | initialValues[i];
                FillCombinationsRecursive(nextCombination, i + 1, initialValues, combinations);
            }
        }
        private void FillCombinationsRecursive<TEnum>(ulong combination, int start, ulong[] initialValues, HashSet<TEnum> combinations) where TEnum : struct
        {
            combinations.Add((TEnum)Enum.ToObject(typeof(TEnum), combination));
            if (combination == 0)
                return;
            for (int i = start; i < initialValues.Length; i++)
            {
                var nextCombination = combination | initialValues[i];
                FillCombinationsRecursive(nextCombination, i + 1, initialValues, combinations);
            }
        }
