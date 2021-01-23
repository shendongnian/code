    public class MutableWibble : Wibble
    {
      public string Foo {get; set;}
      public string Bar {get; set;}
    
      public Wibble CreateImmutableWibble() 
      {
        return new Wibble(this.Foo, this.Bar);
      }
    }
