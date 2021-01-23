    public class Test
    {
      public Dictionary<string, bool> Table {get; set;}
    }
    public void TestMethod()
    {
      Test t = new Test { Table = { {"test", false} } }; //NullReferenceException
    }
