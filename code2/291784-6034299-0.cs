    public abstract class Base{
        public BaseProperty1 bp1 {get; set;} //without abstract identifier
    }
    public class Child : Base
    {
           public new ChildProperty1 bp1 { get; set; } // with new modifier
    }
