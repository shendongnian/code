    public interface IService1
    {
        void MyMethod(string text, bool flag = true);
    }
    
    public class MyService1a : IService1
    {
        public void MyMethod(string text, bool flag) { }
    }
