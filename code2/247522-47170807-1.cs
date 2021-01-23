    class A
    {
         private DbContext_DB;
         private DbContextTransaction _trans;
        
         [SetUp]
         public void setup()
         {
            DB = new DbContext();//create your db context
            _trans = DB.Database.BeginTransaction();
         }
         [TearDown]
         public void done()
         {
            _trans.Rollback();
            DB = null;
         }
    }
