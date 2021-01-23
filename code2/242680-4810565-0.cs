    public class MyDao 
    {
        IFactory<MyDataContext> _contextFactory;
        public MyDao(IFactory<MyDataContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
        
        public Foo GetFooById(int fooId)
        {
            using (var context = _contextFactory.Get())
            {
                return context.Foos.Single(f => f.FooId == fooId);
            }
        }
    }
