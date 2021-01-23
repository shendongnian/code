        List<Type> types = new List<Type>(new Type[] {
            typeof(Boolean)
            , typeof(int)
            , typeof(double)
            , typeof(DateTime)
        });
        string t = "true";
        object retu;
        foreach (Type type in types)
        {
            TypeConverter tc = TypeDescriptor.GetConverter(type);
            if (tc != null)
            {
                try
                {
                    object obj = tc.ConvertFromString(t); // your return value;
                }
                catch (Exception)
                {
                    continue;
                }
            }
        }
