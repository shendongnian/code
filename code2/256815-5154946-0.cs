    public class MyClass
    {
        ThisTypeFromExternalAssembly variable;
        static MyClass( )
        {
            InitialiseExternalLibrary( );
        }
        public MyClass( )
        {
             variable = new ThisTypeFromExternalAssembly( );
        }
    }
