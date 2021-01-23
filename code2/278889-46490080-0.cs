    public interface IFoo {
      IBar Bar { get; }
    }
    public class Foo : IFoo {
      Bar Bar { get; set; }
      IBar IFoo.Bar => Bar;
    }
