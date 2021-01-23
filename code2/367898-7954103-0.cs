    interface IMovable {
      void DoStuff();
    }
    class ImplementinIMovableClass : IMovable {
      void DoStuff() { .. }
    }
    protected static IMovable i = new ImplementinIMovableClass();
