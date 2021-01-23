    public static string GetDescription(this MyStringEnum enumerationValue)
    {
        Type type = enumerationValue.GetType();
        string name = enumerationValue.ToString();
        //Tries to find a DescriptionAttribute for a potential friendly name for the enum
        MemberInfo[] member = type.GetMember(name);
        if (member != null && member.Length > 0)
        {
            object[] attributes = member[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes != null && attributes.Length > 0)
            {
                //Pull out the description value
                return ((DescriptionAttribute)attributes[0]).Description;
            }
        }
        return name;
    }
