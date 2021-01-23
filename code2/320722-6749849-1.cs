     public static string GetDescription(Enum en)
            {
                Type type = en.GetType();
    
                MemberInfo[] info = type.GetMember(en.ToString());
    
                if (info != null && info.Length > 0)
                {
                    object[] attrs = info[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
    
                    if (attrs != null && attrs.Length > 0)
                    {
                        return ((DescriptionAttribute)attrs[0]).Description;
                    }
                }
    
                return en.ToString();
            }
