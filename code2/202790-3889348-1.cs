    public class Foo {
       public static void Bar() {
            var st = new StackTrace();
            var frame = st.GetFrame(0);
            var methodBase = frame.GetMethod();
            var type = methodBase.DeclaringType;
       }
    }
