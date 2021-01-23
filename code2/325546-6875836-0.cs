    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                ExampleClass ec = new ExampleClass();
    
                ec.ID = 10;
    
                Console.ReadKey();
            }
        }
    
        [ComplexAspect]
        class ExampleClass
        {
            public int ID { get; set; }
            public string Name { get; set; }
    
            public ExampleClass()
            {
                //Setup
                Name = "John Smith";
            }
        }
    
        [Serializable]
        public class ComplexAspect : InstanceLevelAspect
        {
            [OnMethodExitAdvice, MulticastPointcut(MemberName=".ctor")]
            public void OnExit(MethodExecutionArgs args)
            {
                //Object should be initialized, do work.
                string value = ((ExampleClass)args.Instance).Name;
                Console.WriteLine("Name is " + value);
            }
    
            [OnLocationGetValueAdvice, MulticastPointcut(Targets=MulticastTargets.Property )]
            public void OnGetValue(LocationInterceptionArgs args)
            {
                Console.WriteLine("Get value for " + args.LocationName);
                args.ProceedGetValue();
            }
    
            [OnLocationSetValueAdvice, MulticastPointcut(Targets = MulticastTargets.Property)]
            public void OnSetValue(LocationInterceptionArgs args)
            {
                Console.WriteLine("Set value for " + args.LocationName);
                args.ProceedSetValue();
            }
    
            public override void RuntimeInitializeInstance()
            {
                base.RuntimeInitializeInstance();
            }
    
        }
    }
