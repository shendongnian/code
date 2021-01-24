    public class MyCustomClass
    {
       private TestClass testClass;
       public MyCustomClass(TestClass testClass)
       {
          this.testClass = testClass;
       }
    
       public void MyMethod()
       {
          var usersClaims = this.testClass.GetClaims();
       }
    }
