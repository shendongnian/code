    public interface IDoSomething
    {
         void DoSomething();
    }
    public class Foo : IDoSomething
    {
        public void DoSomething()
        {
             // Does Something specific to Foo
        }
    }
    public class Bar : IDoSomething
    {
        public void DoSomething()
        {
            // Does something specific to Bar
        }
    }
    public class MyClassFactory
    {
         private static Dictionary<string, Type> _mapping = new Dictionary<string, Type>();
         static MyClassFactory()
         {
              _mapping.Add("Foo", typeof(Foo));
              _mapping.Add("Bar", typeof(Bar));
         }
         public static void AddMapping(string query, Type concreteType)
         {
              // Omitting key checking code, etc. Basically, you can register new types at runtime as well.
              _mapping.Add(query, concreteType);
         }
         public IDoSomething GetMySomething(string desiredThing)
         {
              if(!_mapping.ContainsKey(desiredThing))
                  throw new ApplicationException("No mapping is defined for: " + desiredThing);
              return Activator.CreateInstance(_mapping[desiredThing]) as IDoSomething;
         }
    }
