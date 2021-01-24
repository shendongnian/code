    public abstract class LabeledValueBase {
        public string? Label { get; set; }
    }
    
    public abstract class LabeledStructValue<TValueType> : LabeledValueBase
    where TValueType : struct {
        public TValueType? Value { get; set; }
    }
    
    public abstract class LabeledClassValue<TValueType> : LabeledValueBase
    where TValueType : class {
        public TValueType? Value { get; set; }
    }
