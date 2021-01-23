     [LogMethodCallAttribute(typeof(MyCustomAttribute))]
     class MyClass
     {
          public class LogMe()
          {
          }
          [MyCustomAttribute]
          public class DoNotLogMe()
          {
          }
     }
