    /// <summary>
    /// Phone number.
    /// </summary>
    [TypeConverter(typeof(StringTypeConverter<PhoneNumber>))]
    public class PhoneNumber : StronglyTyped<string>
    {
        /// <inheritdoc />
        public PhoneNumber(string value)
            : base(value.Trim())
        {
        }
        /// <inheritdoc />
        protected override bool IsValid(string value)
        {
            if (value.Trim() == string.Empty)
            {
                return false;
            }
            // Validation logic goes here
            return true;
        }
    }
