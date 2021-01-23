    /// <summary>
    /// Represents results returned from Microsoft Enterprise Library Validation. See <see cref="MSValidation.ValidationResult"/>.
    /// </summary>
    [DataContract]
    public sealed class ValidationResult : IValidationResult
    {
        [DataMember(Order = 0)]
        public String Key { get; private set; }
        [DataMember(Order = 1)]
        public String Message { get; private set; }
        [DataMember(Order = 3)]
        public List<IValidationResult> NestedValidationResults { get; private set; }
        [DataMember(Order = 2)]
        public Type TargetType { get; private set; }
        public ValidationResult(String key, String message, Type targetType, List<ValidationResult> nestedValidationResults)
        {
            Key = key;
            Message = message;
            NestedValidationResults = new List<IValidationResult>(nestedValidationResults);
            TargetType = targetType;
        }
    }
