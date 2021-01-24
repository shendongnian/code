    /// <summary>
    /// Strongly-typed value based on inner type (e.g. <see cref="string"/> or <see cref="System.Uri"/>).
    /// If you need validation then implement ".IsValid()" method.
    /// </summary>
    /// <typeparam name="TInnerType">Type of the inner value.</typeparam>
    public abstract class StronglyTyped<TInnerType> : IStronglyTyped<TInnerType>
    {
        /// <summary>
        /// Validation error format. Should contain "{0}" placeholder.
        /// </summary>
        protected virtual string ValidationErrorFormat => "'{0}' is not valid value";
        /// <summary>
        /// Inner value.
        /// </summary>
        public TInnerType Value { get; }
        /// <inheritdoc />
        protected StronglyTyped(TInnerType value)
        {
            Validate(value);
            Value = value;
        }
        private void Validate(TInnerType value)
        {
            if (!IsValid(value)) throw new StrongTypeException(GetType(), String.Format(ValidationErrorFormat, value));
        }
        /// <summary>
        /// Validates the value.
        /// </summary>
        /// <returns>'true' if value is valid.</returns>
        protected virtual bool IsValid(TInnerType value)
        {
            return true;
        }
        /// <inheritdoc />
        public override string ToString()
        {
            return Value.ToString();
        }
        /// <summary>
        /// Checks the equality of the inner values.
        /// </summary>
        protected bool Equals(StronglyTyped<TInnerType> other)
        {
            return string.Equals(Value, other.Value);
        }
        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((StronglyTyped<TInnerType>)obj);
        }
        /// <inheritdoc />
        public override int GetHashCode()
        {
            return (Value != null ? Value.GetHashCode() : 0);
        }
        /// <summary>
        /// Implicit mapping to `string`.
        /// </summary>
        public static implicit operator string(StronglyTyped<TInnerType> obj)
        {
            return obj?.ToString();
        }
    }
