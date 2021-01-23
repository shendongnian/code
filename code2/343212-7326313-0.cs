    public class Parent
    {
        public int Prop1 { get; set; }
        public string Prop2 { get; set; }
        public DateTime Prop3 { get; set; }
        public T ToChild<T>() where T : Parent, new()
        {
            T child = new T();
            child.Prop1 = this.Prop1;
            child.Prop2 = this.Prop2;
            child.Prop3 = this.Prop3;
            return child;
        }
    }
