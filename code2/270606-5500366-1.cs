    public static IEnumerable<KeyValuePair<int, string>> ToListOfKeyValuePairs<TEnum>(this TEnum enumeration) where TEnum : struct
    {
        return from TEnum e in Enum.GetValues(typeof(TEnum))
                select new KeyValuePair<int, string>
                    (
                        (int)Enum.Parse(typeof(TEnum), e.ToString()),
                        Regex.Replace(e.ToString(), "[A-Z]", x => string.Concat(" ", x.Value[0])).Trim()
                    );
    }
