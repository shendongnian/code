    public class Base<TSelf> where TSelf : Base<TSelf> 
    {
        // Make this a property if you want.
        public IRepository<TSelf> GetTable()
        {                   
            return _container.Resolve<IRepository<TSelf>>();          
        }
    }
    
    public class Derived : Base<Derived> {  }
