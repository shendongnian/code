    public abstract class ValueBase {
        public abstract double Value { get; }
        internal ValueBase() {}
    }
    public abstract class Value : ValueBase {
        internal Value() {}
    }
    public sealed class ValueReal : Value {
        public override double Value { get { return 123; } }
    }
