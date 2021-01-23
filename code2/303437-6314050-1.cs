    public interface IMyContainer<out T> { }
    public class MyContainer<T> : IMyContainer<T> 
    {
        public MyContainer(T value) { }
    }
    public class MyBase { }
    public class A : MyBase { }
    public class B : MyBase { }
    public class GenericConstraintsTest
    {
        private List<IMyContainer<MyBase>> myList = new List<IMyContainer<MyBase>>();
        public GenericConstraintsTest()
        {
            MyContainer<A> ca = new MyContainer<A>(new A());
            this.Add<A>(new A());
            this.Add<B>(new B());
        }
        public void Add<S>(S value) where S : MyBase
        {
            MyContainer<S> cs = new MyContainer<S>(value);
            myList.Add(cs);
        }
        public static void Main()
        {
            GenericConstraintsTest gct = new GenericConstraintsTest();
        }
    }
