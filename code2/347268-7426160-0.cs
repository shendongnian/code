    public abstract class Base
    {
        // Automatic Property
        public string Prop1 { get; set; }
        // With backing field
        private string prop2;
        public string Prop2
        {
            get { return prop2; }
            set { prop2 = value; }
        }
    }
    public class Derived : Base
    {
        public string Prop3 { get; set; }
    }
    public class AnotherClass
    {
        void Foo()
        {
            var derived = new Derived();
            // Can get and set all properties
            derived.Prop1 = derived.Prop1;
            derived.Prop2 = derived.Prop2;
            derived.Prop3 = derived.Prop3;
        }
    }
