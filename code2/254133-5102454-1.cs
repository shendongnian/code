    using System.Reflection;
    
    public object GetObjectFromString()
    {
    
    string objectName = "WpfApplication1.uc1";
    
                Type newType = Type.GetType(objectName, true, true);
    
                object o = Activator.CreateInstance(newType);
    
    // do what you want with the 'o' variable, maybe cast it to the type you want.
    }
