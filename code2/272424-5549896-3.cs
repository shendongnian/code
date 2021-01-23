    public string[] GetClassStaticNames(Type T)
    {
        string[] names;
        System.Reflection.PropertyInfo[] props = T.GetProperties(); // This will return only properties not fields! For fields obtaining use T.GetFields();
        names = new string[props.Count()];
        for (int i = 0; i < props.Count(); i++)
        {
            names[i] = props[i].Name;
        }
        return names;
    }
