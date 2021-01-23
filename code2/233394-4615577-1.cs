    private static Dictionary<Type,string> friendlyNames=new Dictionary<Type,string>();
    static MyClass()//static constructor
    {
      friendlyNames.Add(typeof(bool),"bool");
      ...
    }
    public static string GetFriendlyName(Type t)
    {
      string name;
      if( friendlyNames.TryGet(t,out name))
        return name;
      else return t.Name;
    }
    
