    using System;
    using Zero;
    
    namespace Model.First.Second.Third
    {
        public class WorkerBL
        {
            [MethodGetter]
            public void GetName(Worker worker)
            {
                Console.WriteLine(MethodHelper.GetMethod());
            }
    
            public void NoAttribute(Worker worker)
            {
                Console.WriteLine(MethodHelper.GetMethod());
            }
        }
    }
