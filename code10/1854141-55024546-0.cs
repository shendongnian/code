    public class Program
    {
        private BaseClass _child = GetChildClass();
    
        public void MethodOne()
        {
            DoSomething(_child);
        }
    
        public void MethodTwo()
        {
            DoSomething(_child);
        }
    }
