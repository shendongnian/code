    public class SomeGridRow
    {
      public string Code { get;set; }
      public const string Code = "Code";
      public void MyMethod() {
        var thing = Code; //what would this reference?
      }
    }
