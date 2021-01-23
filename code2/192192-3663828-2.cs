      public class MyArgumentNullException : ArgumentNullException
      {
          public MyArgumentNullException(string name, Type type) 
              :base(name + "must be a " + type.Name + " object");
      }
