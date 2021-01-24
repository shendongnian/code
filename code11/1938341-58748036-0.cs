    public class UpdateRequest
    {
        [MaxLength(80)]
        public string Name
        {
            get => OptionalName.Value;
            set => OptionalName = new OptionalField<string>(value);
        }
    
        [NotNullOrWhiteSpaceIfSet]
        [DisplayName("Name")]
        public OptionalField<string> OptionalName { get; private set; }
    }
    public struct OptionalField<T>
    {
        public OptionalField(T value)
        {
            Value = value;
            HasValue = true;
        }
    
        public T Value { get; set; }
    
        public bool HasValue { get; set; }
    }
