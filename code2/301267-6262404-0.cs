    public class A : IA, IB
    {
        public void Method1();
        //...
        public void MethodN();
        IA IB.Item
        {
            get
            {
                return this;
            }
        }
    }
