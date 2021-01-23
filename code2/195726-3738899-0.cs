    public class SomeFactory
    {
      private static SomeFactory instance = new SomeFactory();
    
      public static SomeFactory Instance
      {
          get
          {
              return instance;
          }
      }
    
      private static Dictionary<Type, Type> classes = new Dictionary<Type, Type>();
    
      static SomeFactory()
      {
          // add here classes that would be created by a factory
          classes.Add(typeof(IClass1), typeof(Class1));
          classes.Add(typeof(IClass2), typeof(Class2));
      }
    
      public T Create<T>()
      {
          return (T)System.Activator.CreateInstance(repos[typeof(T)]);
      }
    }
