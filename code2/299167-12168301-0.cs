    public class Foo {
        public int Time { get; set; }
    }
    public static class ExtensionMethods {
        public static int? GetNullableTime(this Foo foo) {
            if (foo == null)  return null;    // Cast is implicit.
            return foo.Time;
        }
    }
