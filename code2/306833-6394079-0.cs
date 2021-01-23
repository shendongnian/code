    public interface IFoo
    {
        int Test(int myParameter);
        int TestInternal(int myParameter);
    }
    public class Foo : IFoo
    {
        private int _someConstructorArgument;
        public Foo(int someConstructorArgument)
        {
            _someConstructorArgument = someConstructorArgument;
        }
        public virtual int Test(int myParameter)
        {
            return _someConstructorArgument + TestInternal(myParameter);
        }
        public virtual int TestInternal(int myParameter)
        {
            return myParameter;
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            var mock = new Mock<Foo>(MockBehavior.Loose, 50);
            
            mock.Setup(x => x.TestInternal(100))
                .Returns(200);
            mock.CallBase = true;
            Console.WriteLine(mock.Object.Test(100));
            Console.ReadLine();
        }
    }
