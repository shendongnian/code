    public class NormalFooUser : IFooUser
    {
        private readonly Func<Int32, IFoo> _fooBuilder;
        public NormalFooUser(Func<Int32,IFoo> fooBuilder)
        {
            _fooBuilder = fooBuilder;
        }
        public void useFoo(Int32 score)
        {
            _fooBuilder(score).foo();
        }
    }
