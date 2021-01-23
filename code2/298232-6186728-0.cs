    [CodedUITest]
    public class SomeClass
    {
      public static string MyStaticProp { get; set; }
      static SomeClass(){
        MyStaticProp = "AHA";
      }
      ...
    }
