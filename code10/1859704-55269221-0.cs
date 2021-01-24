    ////  your list object
    List<MyClass> classCollection = new List<MyClass>();
    
    //// To set value in session
    HttpContext.Session.Set<List<MyClass>>("someKey", classCollection);
    
    //// To Get Value from Session
    List<MyClass> classCollection = HttpContext.Session.Get<List<MyClass>>("someKey");
