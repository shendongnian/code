    using System;
    using System.Collections.Generic;
    using System.Linq;
    //public interface IThing {} 
    public class MachineClass /* : IThing */ { }
    public class AnimalClass  /* : IThing */ { }
    public class Plane        /* : IThing */ { }
    public class Program
    {
         public enum Things
         {
             Car,
             Animal,
             Plane
         }
         private static readonly IDictionary<Things, string> _classNameMap = 
             new Dictionary<Things, string> {
              { Things.Car,    "MachineClass" },
              { Things.Animal, "AnimalClass"  },
              { Things.Plane,  "FlyClass"     }  };
         public static void Main(string[] args)
         {
             var realtypes = _classNameMap.ToDictionary(
                     kvp => kvp.Key,
                     kvp => System.Type.GetType(/*"Namespace." +*/ kvp.Value));
             Type dynamicType = realtypes[Things.Plane]; // typeof(Namespace.FlyClass)
             foreach (var realtype in realtypes)
                 Console.WriteLine("{0}, class {1}", 
                         realtype.Key, realtype.Value);
         }
    }
