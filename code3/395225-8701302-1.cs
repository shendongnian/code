    public void SerializeAllColors()
    {
        Type colorType = typeof(System.Drawing.Color);
        PropertyInfo[] properties = colorType.GetProperties(BindingFlags.Public | BindingFlags.Static);
        foreach (PropertyInfo p in properties)
        {
            string name = p.Name;
            Color c = p.GetGetMethod().Invoke(null, null);
    
            //do your serialization with name and color here
        }
    }
