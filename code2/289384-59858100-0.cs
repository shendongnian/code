    public class MyBase
    {
        public void MethodA()
        {
            //Do things
        }
    }
    public interface IMyInterface
    {
        void MethodA();
        void MethodB();
    }
    public class MySub: MyBase, IMyInterface
    {
        public void MethodB()
        {
            //Do things
        }
    }
