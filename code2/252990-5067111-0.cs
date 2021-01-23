    class Base<TSelf> where TSelf : Base<TSelf> 
    {
        public IRepository<TSelf> Table
        {
             return _container.Resolve<IRepository<TSelf>>();
        }
    }
    
    public class Derived : Base<Derived>{ }
