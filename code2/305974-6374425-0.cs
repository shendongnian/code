    interface IRepository {  /* methods and properties */ }
    interface IUserRepository : IRepository {}
    interface ICentralRepository : IRepository {}
    class Foo
    {
       public Foo(IUserRepository userRepo, ICentralRepository centralRepo)
       {
          // assign to fields
       }
    }
    
