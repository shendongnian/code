    public class MyClass
    {
        public static dynamic StaticDynamicObject;
        static MyClass()
        {
            StaticDynamicObject = new ExpandoObject();
            StaticDynamicObject.Prop = "woohoo!";
        }
    }
