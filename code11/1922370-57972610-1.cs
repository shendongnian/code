    using System;
    using System.Reflection;
    using System.Collections.Generic;
    namespace ConsoleApp1
    {
      public abstract class Food { }
      public abstract class Meat : Food { }
      public class Beef : Meat { }
      public class Chicken : Meat { }
      public abstract class Vegetable : Food { }
      public class Lettuce : Vegetable { }
      public class Tomato : Vegetable { }
      public class Carrots : Vegetable { }
      class Program
      {
        static List<Type> toPrint = new List<Type>();
        static string GetCategories(List<Type> list)
        {
          var result = new List<string>();
          foreach ( var item in list )
            foreach ( var type in Assembly.GetExecutingAssembly().GetTypes() )
              if ( type.IsSubclassOf(item) )
                result.Add(type.Name);
          return String.Join(", ", result.ToArray());
        }
        static void Main()
        {
          toPrint.Add(typeof(Meat));
          toPrint.Add(typeof(Vegetable));
          Console.WriteLine(GetCategories(toPrint));
          Console.ReadKey();
        }
      }
    }
