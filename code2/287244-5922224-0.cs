    public abstract class A
    {
        public abstract int Value { get; }
    }
    public class B : A
    {
        public override int Value { get { return 1; } }
    }
    public class C : A
    {
        public override int Value { get { return 2; } }
    }
