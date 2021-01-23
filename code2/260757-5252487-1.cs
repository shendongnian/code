    public class MyClass
    {
      public int World { get; set; }
    }
    ...
    var c = new MyClass();
    Console.WriteLine("Hello {0}", PropertyName(() => c.World));
    
