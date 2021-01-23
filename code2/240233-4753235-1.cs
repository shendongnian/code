    namespace TestDrive
    {
        using System;
        class Program
        {
            static void Main()
            {
                try
                {
                    ClassLibrary1.Widget x = new ClassLibrary1.Widget() ;
                    x.Foo() ;
                }
                catch ( Exception e )
                {
                    Type t = e.GetType() ;
                    if ( t.Module.Name == "ClassLibrary1" && t.FullName  == "ClassLibrary1.InternalException" )
                    {
                        // do something ;
                    }
                }
            }
        }
    }
