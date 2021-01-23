    class A
    {
         private static readonly object listLock = new object();
         private static List<MyClass> classes = new List<MyClass>();
    
         public void Method1()
         {
              lock(listLock)
              {
                   //update here
              }
         }
    
         public List<MyClass> Method2()
         {
              lock(listLock)
              {
                   return classes;
              }
         }
    
    }
