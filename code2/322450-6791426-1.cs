    public class MyClass : MyBaseClass
    {
         public void GetData()
         {
              using(DbDataContext db = new DbDataContext())
              {
                  // DO STUFF
              }
         }
         public void PerformLogicallyAtomicAction()
         {
              using(DbDataContext db = new DbDataContext())
              {
                  // DO STUFF
              }
         }
    }
