    public abstract class Foo
    {
        public string StaticValue 
        {
            get
            {
				FieldInfo targetField = GetType().GetField("staticValue");
                return (string)targetField.GetValue(null);
            }
        }
    }
    public class MyFirstFoo: Foo
    {
        public static string staticValue = "A first attempt to foo-ize Foo.";
    }
    public class MySecondFoo: Foo
    {
        public static string staticValue = "A second attempt to foo-ize Foo.";
    }
