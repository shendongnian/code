    class Test
    {
      private method myMethod()
       {}
      protected method myprotectedMethod()
       {}
    }
    
    
    class ChildTest : Test
    {
      public method useProtectedBaseMethod ()
      {
         this.myProtectedMethod(); // this is ok
         this.myMethod(); // this is NOT ok. will throw an Error
      }
    }
    
    class outsider
    {
      Test  objTest = new Test();
      objTest.myProtectedMethod(); // throws an error as it is not accessible
      objTest.myMethod(); // throws an error as it is not accessible
    }
