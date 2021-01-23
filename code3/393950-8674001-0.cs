    public class TestData
    {
      public int Id { get; set; }
      public long Value { get; set; } 
    }
    while (true)
    {
      LinkedList<TestData> test = new LinkedList<TestData>();
      for(int i = 0;i< 3000000;i++)
      {
        test.AddLast(new TestData() { Id = 0, Value = i });
      }
      Console.WriteLine("Start Linq");
      var orderdlist = test.ToList();
      Console.WriteLine("End Linq");
    }
