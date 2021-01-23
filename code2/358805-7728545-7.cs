    static IEnumerable<ToType> foo<ToType>(Type typeEnum)
    {
        if (typeEnum.IsEnum)
        {
            foreach (var enumVal in Enum.GetValues(typeEnum))
            {
                yield return (ToType)Convert.ChangeType(enumVal, typeof(ToType));
            }
        }
    }
