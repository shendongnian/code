    using System;
    
    namespace FooNamespace
    {
        using System.IO;
    
        class Foo
        {
            // you can use types from System and System.IO directly here
        }
    }
    
    namespace BarNamespace
    {
        class Bar
        {
            // you can't use types from System.IO directly here
            // but you can use types from System
        }
    }
