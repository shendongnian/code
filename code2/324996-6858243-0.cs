    var assembly = typeof(SomeJarToDllAssembly.SomeType).Assembly;
    var type_TestClass1 = assembly.GetType("TestClass$1");
    var method_clinit = type_TestClass.GetMethod("__<clinit>");
    var dlgClinit = (Action<object>)Delegate.Create(type_TestClass, method_clinit);
    
    // call delegate like normal method (it's fast as normal method calling)
    dlgClinit(new object());
