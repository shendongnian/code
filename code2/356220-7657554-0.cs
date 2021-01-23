    public interface ITest1
    {
        void Method1();
    }
    public class interface ITest2 : ITest1
    {
        void Method2();
    }
    public class Test1 : ITest1
    {
        public void Method1() {}
    } 
    public class Test2 : ITest2
    {
        public void Method1() {}
        public void Method2() {}
    } 
