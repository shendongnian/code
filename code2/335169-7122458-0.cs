    partial interface IFoo
    {
        void One();
        void Two();
    }
    
    partial class Class1 : IFoo
    {
        public void Two()
        { }
    
        public void Three()
        { }
    }
