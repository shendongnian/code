    public class FooBarRepository : IFooBarRepository
    {
        Foo IRepository<Foo>.Get(int id)
        {
            return new Foo();
        } 
        Bar IRepository<Bar>.Get(int id)
        {
            return new Bar();
        } 
    }
