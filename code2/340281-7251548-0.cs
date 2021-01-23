    public abstract class MyBase {
        public void Execute() {
            Console.WriteLine(MyString);
        }
        // Notice that this has no body, because it is abstract.  Also, I don't need a setter.
        protected abstract String MyString { get; } 
    }
    public class MyChild : MyBase {
        protected String MyString { get { return "Foo"; } }
    }
    public class MyOtherChild : MyBase {
        protected String MyString { get { return "Bar"; } }
    }
