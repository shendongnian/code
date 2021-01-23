    using (var scope = instance.Scoped()) {
      var _ = scope.Target; // you need an extra line...
      _.Foo = "Hello";
      _.Bar = "World"; 
    }
    ...
    // this class has no meaning by itself
    public class Scope<T> : IDisposable {
      public readonly T Target;
      public Scope(T target) {
        Target = target;
      }
      public void Dispose() { }
    }
    public static class ScopeExtensions {
      public static Scope<T> Scoped<T>(this T instance) {
        return new Scope<T>(instance);
      }
    }
