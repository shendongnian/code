    public class Outer
    {
        public interface IInner
        {
            string SomeMethod();
        }
        class Inner: IInner
        {
            public string SomeMethod()
            {
                return "Hello, World!";
            }
        }
        public IInner CreateInner()
        {
            return new Inner(); // should only be allowed inside this method
        }
    }
