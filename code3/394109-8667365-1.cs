    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Dynamic;
    
    namespace DynamicTest
    {
        public class DynamicDictionary : DynamicObject
        {
            Dictionary<string, object> dict;
    
            public DynamicDictionary(Dictionary<string, object> dict)
            {
                this.dict = dict;
            }
    
            public override bool TrySetMember(SetMemberBinder binder, object value)
            {
                dict[binder.Name] = value;
                return true;
            }
    
            public override bool TryGetMember(GetMemberBinder binder, out object result)
            {
                return dict.TryGetValue(binder.Name, out result);
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                dynamic foo = new DynamicDictionary(new Dictionary<string, object> { { "test1", 1 } });
    
                foo.test2 = 2;
    
                Console.WriteLine(foo.test1); // Prints 1
                Console.WriteLine(foo.test2); // Prints 2
            }
        }
    }
