    static class Fooness {
      public static operator==(IFoo l, IFoo r) { ... }
    }
    static class Barness {
      public static operator==(IBar l, IBar r) { ... }
    }
    public class Foobar : IFoo, IBar { ... }
