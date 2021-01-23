    static void foo(Type typeEnum)
    {
        if (typeEnum.IsEnum)
        {
            foreach (var enumVal in Enum.GetValues(typeEnum))
            {
                var _val = Convert.ToInt64(enumVal);                      
            }
        }
    }
