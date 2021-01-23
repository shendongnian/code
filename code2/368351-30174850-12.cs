    public static string GetDescription<T>(this T e) where T : IConvertible
    {
        Array values = System.Enum.GetValues(e.GetType());
        string description = null;
        foreach (int val in values)
        {
            if (val == e.ToInt32(CultureInfo.InvariantCulture))
            {
                var type = e.GetType();
                var memInfo = type.GetMember(Enum.GetName(type, val));
                var attributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                description = ((DescriptionAttribute)attributes[0]).Description;
            }
        }
        return description;
    }
