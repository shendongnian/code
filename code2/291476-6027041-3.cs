    class Foo {
      public static int X; // 0
      public static int Y; // 0
      static Foo() {
        X = Y; // 0
        Y = 3; // 3
      }
    }
