    // untested, schematic
    void ShowType(Object x)
    {
       Write(x.GetType().Name);  // depends on actual type
       // typeof(x) won't actually compile
       Write(typeof(x).Name);   // always System.Object
    }
    
    ShowType("test");
