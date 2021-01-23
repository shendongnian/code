    class MyClass
    {
        public int Prop1 { get; set; }
        public int Prop2 { get; set; }
        public int Prop3 { get; set; }
        public override bool Equals(object obj)
        {
            return ((MyClass)obj).Prop2 == Prop2;
        }
        public override int GetHashCode()
        {
            return Prop2.GetHashCode();
        }
    }
