    using System.Reflection;
    
    // ...
    
    Version version = typeof(MainPage).GetTypeInfo().Assembly.GetName().Version;
