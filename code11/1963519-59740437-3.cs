    public abstract class LabeledValue<TValue> {
        public string? label { get; set; }
        [AllowNull, MaybeNull]
        public TValue value { get; set; }
    }
