    class A
    {
         private TransactionScope _trans;
        
         [SetUp]
         public void setup()
         {
            _trans = new TransactionScope();
         }
         [TearDown]
         public void done()
         {
            if(_trans != null)
              _trans.Dispose();
         }
         [Test]
         public void doSomeDbWrite()
         {
             //your code to insert/update/delete data in db
         }
    }
