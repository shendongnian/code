    public class Foo {
       public static void Bar() {
            Type type = new StackTrace().GetFrame(0).GetMethod().DeclaringType;
       }
    }
