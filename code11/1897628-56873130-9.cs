    class Test : ITest {
      ...
      public void SomeMethod() 
      {
         // we can't put method's name as it is `SomeNamespace.ITest.Test`
         // Let's find it and execute
         var method = this
           .GetType()
           .GetMethod($"{(typeof(ITest)).FullName}.Test", 
                        BindingFlags.Instance | BindingFlags.NonPublic);
         method.Invoke(this, new object[0]);
      } 
 
