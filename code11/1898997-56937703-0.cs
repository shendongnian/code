    abstract class Parent<T> where T : IDB
    {
        protected T DB;
        public Parent(T database) {
            DB = database;
        }
        public void Foo() 
        {
            DB.Bar()
        }
    }
    class Child : Parent<IDB_Child>
    {
        public Child1(IDB_Child database) : base(database) {}
        public void ChildFoo() 
        {
            DB.Bar()
        }
    }
