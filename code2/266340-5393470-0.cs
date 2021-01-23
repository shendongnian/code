    class Test
    {
       private int abc = 0;
    
       public class TestClass
       {
          private void changeABC(Test test)
          {
             test.abc = 123;
          }
       }
    }
