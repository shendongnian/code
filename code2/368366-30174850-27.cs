    public static string GetDescription<T>(this T e) where T : IConvertible
    {
        string description = null;
        if (e is Enum)
        {
            Type type = e.GetType();
            Array values = System.Enum.GetValues(type);
            foreach (int val in values)
            {
                if (val == e.ToInt32(CultureInfo.InvariantCulture))
                {
                    var memInfo = type.GetMember(type.GetEnumName(val));
                    var attributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                    if(attributes.Length > 0)
                    {
                        description = ((DescriptionAttribute)attributes[0]).Description;
                    }
                    break;
                }
            }
        }
        return description;
    }
