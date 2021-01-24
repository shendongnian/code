    public class Logic
    {
        [FieldIWantToSet] public MyObject Object001; // will be set
        [FieldIWantToSet] public MyObject Foo;  // will be set
        public MyObject Bar;  // will not be set
    }
