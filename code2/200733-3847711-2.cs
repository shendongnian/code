    public class Foo
    {
      public string Name { get; set; }
 
      public static implicit operator Foo(string value)
      {
        return new Foo { Name = value };
      }
    }
    ...
    Foo foo = "fooTest";
    Console.WriteLine("Foo name: {0}", foo.Name);
    ...
