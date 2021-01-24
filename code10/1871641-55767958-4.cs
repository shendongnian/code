    using System;
    using Zero;
    
    namespace ConsoleApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                var worker = new Worker();
                foreach (var d in Discovery.GetDelegates<MethodGetterAttribute, Action<Worker>>())
                    d.Invoke(worker);
            }        
        }
    
        public class WorkerBL
        {
            [MethodGetter]
            public void GetName(Worker worker)
            {
                Console.WriteLine(MethodHelper.GetMethod());
            }
        }
    }
