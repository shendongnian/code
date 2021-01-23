    class MyDispatchTable : DispatchTable<MyClass, string, EventHandler>
    static MyDispatchTable dispatchTable = new MyDispatchTable
    {
        { "Event1", c => c.EventHandler1 }
        ,{ "Event2", c => c.EventHandler2 }
    }; 
