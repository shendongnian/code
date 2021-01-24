    public class MyClass() 
    {
        public Foo a;
        public Foo b;
        public Foo c;
        public Foo d;
        public Foo e;
        
        MyClass() 
        {
            Foo[] foos = GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
                .Where(fieldInfo => fieldInfo.FieldType.Equals(typeof(Foo)))
                .Select(fieldInfo => fieldInfo.GetValue(this))
                .Cast<Foo>()
                .ToArray();
            foreach(Foo foo in foos) 
            {
                foo.Setup();
            }
        }
    }
