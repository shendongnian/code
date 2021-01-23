    class Test
    {
      public decimal? Val { get; set; }
    }
    class Program
    {
      static void Main(string[] args)
      {
        object o = new Test();
        object source = 5;
        var setMethod = typeof(Test).GetProperty("Val").GetSetMethod();
        // Just do the cast explicitly
        setMethod.Invoke(o, new object[] { (decimal?)(int)source });
      }
    }
