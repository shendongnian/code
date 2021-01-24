    using System;
    using Zero;
    
    namespace Model.First.Second
    {
        public class PersonBL
        {
            [MethodGetter]
            public void GetName(Person person)
            {
                Console.WriteLine(MethodHelper.GetMethod());
            }
    
            [MethodGetter]
            public void Incompatible(string s)
            {
                Console.WriteLine(MethodHelper.GetMethod());
            }
        }
    }
