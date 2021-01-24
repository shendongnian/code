    public class Bar : Foo
    {
        public new int SomeProperty
        {
            get => base.SomeProperty;
            set => base.SomeProperty = value;
        }
    }
