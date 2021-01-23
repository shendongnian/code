    void Main()
    {
    	Foo f = new Foo();
    	if ((Id ?? 0) == 0) {} // if (f.Id == null || f.Id == 0) {}
    }
    
    // Define other methods and classes here
    public class Foo
    {
      public int? Id { get; set; }
    }
