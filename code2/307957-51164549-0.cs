    namespace System {
      public static class MyExtensions {
        public static bool IsNull(this object T) {
          return T is null;
        }
        public static bool NotNull(this object T) {
          return !(T is null);
        }
      }
    }
