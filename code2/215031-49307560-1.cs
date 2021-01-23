    public static string GetEnumString(MyEnum inEnumValue)
    {
        StringBuilder sb = new StringBuilder();
    
        foreach (MyEnum e in Enum.GetValues(typeof(MyEnum )))
        {
            if ((e & inEnumValue) != 0)
            {
               sb.Append(e.ToString());
               sb.Append(", ");
            }
        }
       return sb.ToString().Trim().TrimEnd(',');
    }
