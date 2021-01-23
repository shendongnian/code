    public abstract class Parent<TProp> where TProp : BaseProperty1
    {
        public abstract T bp1 { get; set; }
    }
    public abstract class Child : Parent<ChildProperty1>
    {
        public ChildProperty1 bp1 { get; set; }
    }
