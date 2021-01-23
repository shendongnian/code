    instance.With(_ => {
      _.Foo = "Hello";
      _.Bar = "World"; 
    };
    ...
    public static class WithExtensions {
      public static void With<T>(this T instance, Action<T> action) {
        action(instance);
      }
    }
