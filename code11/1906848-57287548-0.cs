    public class AnonymizerAttribute : Attribute
    {
        public Type Type { get; }
        public AnonymizerAttribute(Type anonymizerType)
        {
            Type = anonymizerType;
        }
    }
