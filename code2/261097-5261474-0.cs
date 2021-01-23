    public class ClassContructorReference
    {
        static void Main(string[] args)
        {
            object var = new object();
            MyClass myClass = new MyClass(var);
            StringBuilder mySb = myClass.Instance as StringBuilder;
            Console.WriteLine(mySb.ToString());
        }
    }
    public class MyClass
    {
        public object Instance {get;set;}
        public MyClass(object var)
        {
            this.Instance = var;
            DoSomething();
        }
        private void DoSomething()
        {
            this.Instance = new StringBuilder("Hello");
        }
    }
