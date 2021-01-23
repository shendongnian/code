    public static void Test2() {
      SomeClass[] SomeClasses; //created somehow
      //in real life, this would be determined dynamically
      var getters=new[] {SomeClass.FirstField, SomeClass.AnotherField, SomeClass.AndAnother};
      foreach(var sc in SomeClasses) {
        foreach(var getter in getters) {
          System.Console.WriteLine(getter(sc));
        }
      }
    }
    public class SomeClass {
      public static readonly Func<SomeClass, string> FirstField=sc => sc.field0;
      public static readonly Func<SomeClass, string> AnotherField=sc => sc.field1;
      public static readonly Func<SomeClass, string> AndAnother=sc => sc.field2;
      private string field0;
      private string field1;
      private string field2;
    }
