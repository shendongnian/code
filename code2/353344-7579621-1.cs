    public enum Test { A, B, C };
    
    public interface IParent1
    {
        string method1(Test test);
    }
    
    public class Parent1 : IParent1
    {
        public string method1(Test test)
        {
            return test.ToString();
        }
    }
