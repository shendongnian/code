    namespace System {
      public static class MyExtensions {
        public static bool IsNull(this object o) => o is null;
        public static bool NotNull(this object o) => !(o is null);
      }
    }
