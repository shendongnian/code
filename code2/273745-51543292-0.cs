        /// <summary>
        /// Returns a Dictionary&lt;int, string&gt; of the parent enumeration. Note that the extension method must
        /// be called with one of the enumeration values, it does not matter which one is used.
        /// Sample call: var myDictionary = StringComparison.Ordinal.ToDictionary().
        /// </summary>
        /// <param name="enumValue">An enumeration value (e.g. StringComparison.Ordianal).</param>
        /// <returns>Dictionary with Key = enumeration numbers and Value = associated text.</returns>
        public static Dictionary<int, string> ToDictionary(this Enum enumValue)
        {
            var enumType = enumValue.GetType();
            return Enum.GetValues(enumType)
                .Cast<Enum>()
                .ToDictionary(t => (int)(object)t, t => t.ToString());
        }
