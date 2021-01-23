    class Program
        {
            [Monitor]
            static void Main(string[] args)
            {
                           
            }
        }
    
        [Serializable]
        public class MonitorAttribute : OnMethodBoundaryAspect
        {
            public override void OnEntry(MethodExecutionArgs args)
            {
                Console.WriteLine("OnEntry");
            }
        }
