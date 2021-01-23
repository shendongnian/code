    public class Foo
    {
      public string Name { get; set; }
      public override bool Equals(object other)
      {
        if (Name == null)
          return (other == null);
        else
          return other != null && Name == (string)other;
      }
      public override int GetHashCode()
      {
        return Name != null ? Name.GetHashCode() : 0;
      }
      public override string ToString()
      {
        return Name;
      }
      public static implicit operator Foo(string value)
      {
        return new Foo { Name = value };
      }
    }
    ...
    Foo foo = "fooTest";
    Console.WriteLine("Foo name: {0}", foo.Name);
    ...
