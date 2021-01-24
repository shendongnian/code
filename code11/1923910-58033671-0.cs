      class Base { }
      class Derived : Base { }
      static class Workers 
      { 
        public static void DoSomething(Derived obj) { Console.WriteLine("Test"); } 
      }
      class Program
      {
        static Dictionary<Type, Action<Base>> actions;
    
        //  *** Note use of dummy to avoid having to know T at compile time and T : Base constraint
        //  (compiler can't infer T from Action<T> alone, this way runtime works out T from given object instance)...
        static void AddAction<T>(T dummy, Action<T> a) where T : Base 
        {
          actions.Add(typeof(T), b => a(b as T));
        }
    
        static void Main(string[] args)
        {
          actions = new Dictionary<Type, Action<Base>>();
          var o = new Derived();  //  the object you get "from elsewhere"
          AddAction(o, Workers.DoSomething);
          actions[o.GetType()](o);
          Console.ReadKey();
        }
      }
