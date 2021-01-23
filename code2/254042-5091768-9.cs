    static List<Color> GetConstants(Type enumType)
    {
        MethodAttributes attributes = MethodAttributes.Static | MethodAttributes.Public;
        PropertyInfo[] properties = enumType.GetProperties();
        List<Color> list = new List<Color>();
        for (int i = 0; i < properties.Length; i++)
        {
            PropertyInfo info = properties[i];
            if (info.PropertyType == typeof(Color))
            {
                MethodInfo getMethod = info.GetGetMethod();
                if ((getMethod != null) && ((getMethod.Attributes & attributes) == attributes))
                {
                    object[] index = null;
                    list.Add((Color)info.GetValue(null, index));
                }
            }
        }
        return list;
    }
