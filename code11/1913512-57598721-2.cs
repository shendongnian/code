    /// <summary>
    /// Generic type converter for converting `string` to `TValue` (and other way around).
    /// </summary>
    public class StringTypeConverter<TValue> : TypeConverter
    {
        /// <inheritdoc />
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string);
        }
        /// <inheritdoc />
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return destinationType == typeof(string);
        }
        /// <inheritdoc />
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value == null)
            {
                return null;
            }
            if (value is string stringValue)
            {
                return CreateInstance(stringValue);
            }
            throw new NotSupportedException($"Can't convert `{value.GetType().Name}` to `{typeof(TValue)}`");
        }
        /// <summary>
        /// Creates instance of `TValue` from string value.
        /// </summary>
        protected TValue CreateInstance(string value)
        {
            return CreateInstanceInternal(value);
        }
        /// <summary>
        /// Creates instance of `TValue` from string value.
        /// </summary>
        protected virtual TValue CreateInstanceInternal(string value)
        {
            if (typeof(IStronglyTyped<string>).IsAssignableFrom(typeof(TValue)))
            {
                return (TValue)Activator.CreateInstance(typeof(TValue), value);
            }
            else
            {
                var typeConverter = TypeDescriptor.GetConverter(typeof(TValue));
                return (TValue)typeConverter.ConvertFromString(value);
            }
        }
        /// <inheritdoc />
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return ((TValue)value)?.ToString();
            }
            throw new NotSupportedException($"Can't convert `{typeof(TValue)}` to `{destinationType.Name}`");
        }
    }
