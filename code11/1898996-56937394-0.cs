    public interface IDB
    {
        void Bar();
    }
    
    abstract class Parent 
    {
        protected IDB DB;
        public Parent(IDB database) {
            DB = database;
        }
        public void Foo()
        {
            DB.Bar();
        }
    }
    class Child : Parent
    {
        public Child(IDBImplem database) : base(database) {}
        public void ChildFoo()
        {
            DB.Bar();
        }
    }
    public class IDBImplem : IDB
    {
        public void Bar()
        {
        }
    }
