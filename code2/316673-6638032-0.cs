    public static void Test1() {
      SomeClass[] SomeClasses; //created somehow
      //in real life, this would be determined dynamically
      var properties=new[] {SomeClass.FirstField, SomeClass.AnotherField, SomeClass.AndAnother};
      foreach(var sc in SomeClasses) {
        foreach(var property in properties) {
          Console.WriteLine(sc.GetData(property));
        }
      }
    }
    public class SomeClass {
      public static readonly MyProperty FirstField=new MyProperty();
      public static readonly MyProperty AnotherField=new MyProperty();
      public static readonly MyProperty AndAnother=new MyProperty();
      private readonly Dictionary<MyProperty, string> myData=new Dictionary<MyProperty, string>();
      public string GetData(MyProperty property) {
        return myData[property];
      }
    }
    //default implementation of Equals and GetHashCode are fine here
    public class MyProperty {}
