namespace ConsoleApplication5
{
    class FunctionToCompareAttribute : Attribute
    {
        public FunctionToCompareAttribute( String className, String methodName )
        {
            ClassName = className;
            MethodName = methodName;
        }
        public String ClassName
        {
            get;
            private set;
        }
        public String MethodName
        {
            get;
            private set;
        }
    }
    class ComparableAttribute : Attribute
    {
    }
    class CompareResult
    {
    }
    [Comparable]
    class ClassToCompare
    {
        [FunctionToCompare( "ConsoleApplication5.ClassToCompare", "MyCompareFunction" )]
        public String SomeProperty
        {
            get;
            private set;
        }
        public static CompareResult MyCompareFunction( Object left, Object right, String propertyName )
        {
            return null;//Comparsion
        }
    }
    class Program
    {
        static void Main( string[] args )
        {
            var left = new ClassToCompare();
            var right = new ClassToCompare();
            var type = typeof( ClassToCompare );
            var typeAttributes = type.GetCustomAttributes( typeof( ComparableAttribute ), true );
            if ( typeAttributes.Length == 0 )
                return;
            foreach ( var property in type.GetProperties() )
            {
                var attributes = property.GetCustomAttributes( typeof( FunctionToCompareAttribute ), true );
                if ( attributes.Length == 0 )
                    continue;
                var compareAttribute = attributes[ 0 ] as FunctionToCompareAttribute;
                var className = compareAttribute.ClassName;
                var methodName = compareAttribute.MethodName;
                var compareType = Type.GetType( className );
                var method = compareType.GetMethod( methodName, new Type[] { type, type, typeof( String ) } );
                var **result** = method.Invoke( null, new Object[] { left, right, property.Name } ) as CompareResult;
            }
        }
    }
}
