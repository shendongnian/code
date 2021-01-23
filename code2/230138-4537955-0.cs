    // untested, schematic
    void ShowType(Object x)
    {
       Write(x.GetType().Name);  // depends on actual type
       Write(typeof(x).Name);   // always System.Object
    }
    
    ShowType("test");
