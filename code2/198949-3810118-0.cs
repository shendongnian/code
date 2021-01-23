    using System;
    using System.Reflection;
    
    class Test
    {
        static void Main()
    	{
            string typeName = "System.NullReferenceException";
            string message = "This is a message";
            Type type = Type.GetType(typeName);
            ConstructorInfo ctor = type.GetConstructor(new[] { typeof(string) });
            object exception = ctor.Invoke(new object[] { message });
            Console.WriteLine(exception);
    	}
    }
