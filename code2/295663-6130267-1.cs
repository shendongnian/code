    public class Sample<T> : BaseClass<T>, IMyInterface
    {
        public Sample<T>(string input)
           : base(input)
        {
        }
        protected override void DoSomething(string input)
        {
        }
        public void MyInterfaceMethod()
        {
        }
    }
