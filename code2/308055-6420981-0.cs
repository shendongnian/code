    s = "Person.Position.PositionTitle.Title";
    string[] split = s.Split(".");
    int i = 0;
    Type t = Type.GetType(split[0]);
    
    object obj = null;
    for (i=0; i < split.Count()-1; i++)
    {
        PropertyInfo pi = t.getProperty(split[i+1]);
        pi.getValue(obj, null);
        t = pi.PropertyType();
    }
    
    result = (string)obj;
