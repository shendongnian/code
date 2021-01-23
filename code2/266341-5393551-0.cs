    class Test
    {
       public Test()
       {
         TestClass test = new TestClass();//create a new **instance** here
         test.changeABC(this);//give the instance of Test to TestClass
         Console.WriteLine(abc);//will print 123 
       }
       int abc = 0;
    
       public class TestClass
       {
          public void changeABC(Test t)
          {
             t.abc = 123;
          }
       }
    }
