    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    
    class NullingExpandoObject : DynamicObject
    {
        private readonly Dictionary<string, object> values
            = new Dictionary<string, object>();
        
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            // We don't care about the return value...
            values.TryGetValue(binder.Name, out result);
            return true;
        }
    
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            values[binder.Name] = value;
            return true;
        }
    }
    
    class Test
    {
        static void Main()
        {
            dynamic x = new NullingExpandoObject();
            x.Foo = "Hello";
            Console.WriteLine(x.Foo ?? "Default"); // Prints Hello
            Console.WriteLine(x.Bar ?? "Default"); // Prints Default
        }
    }
