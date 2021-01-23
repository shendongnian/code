    public interface ITest
    {
        int this[int index] { get;  }
    }
    public class Test : ITest
    {
        public int this[int index]
        {
            get { ... }
            private set { .... }
        }
    }
