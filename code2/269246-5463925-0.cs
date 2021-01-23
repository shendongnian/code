    using System.Collections.Generic;
    using System;
    
    namespace X 
    { 
        class Y : MyBase
        {
            public static void Main(string[]args) { }
    
            public void generate()
            {
                base.generateFoo<Something>(Method<Something>); // works
                base.generateFoo<Something>(Method); // works as well
                base.generateFoo(Method<Something>); // doesn't (cannot be inferred)
            }
    
            public void Method<T>(T t , IDictionary<T, SomeObject> coll) 
                where T : ISomething
            {
                // do something
            }
    
        }
    
        class MyBase
        {
            public void generateFoo<T>(Action<T, IDictionary<T, SomeObject>> Method) 
                where T : class, ISomething
            {
                Method.Invoke((T) null, new Dictionary<T,SomeObject>());
            }
        }
        internal interface ISomething {}
        internal class Something : ISomething {}
        internal class SomeObject {}
    }
