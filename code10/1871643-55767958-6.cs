    using System;
    using Zero;
    
    namespace Model.First
    {
        public class PersonBL
        {
            [MethodGetter]
            public void GetName(Person person)
            {
                Console.WriteLine(MethodHelper.GetMethod());
            }
        }
    }
