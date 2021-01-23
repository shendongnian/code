    public class MyConsumer{
        public void MyMethod(){
            Table1 t1 = new Table1();
            Table1 t2 = new Table2();
            Table1 t3 = new Table3();
            
            t1.UsingMethod2(); // will be called from ITableBaseExtensions
            t1.Method2(); // will be called from ITableBase - must implemented in Table1 class
            
            t2.Method3(some_argument); //  will be called from ITableBase - must implemented in Table2 class
            t2.GetIdAsString(); // will be called from ITableBaseExtensions
    
            // etc.
        }
    }
