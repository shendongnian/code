    public class SomeClass
     {
         private readonly JustOne _work;
         public SomeClass()
         {
             _work = new JustOne();
         }
    
         public bool DoWork()
         {
             return _work.Do(() =>
             {
                 // actual work
             });
         }
           
     }
