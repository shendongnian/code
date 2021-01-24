    internal class JsonLogTypeSerializer : NLog.IJsonConverter
    {
        private NLog.IJsonConverter _originalConverter;
        public JsonLogModelSerializer(NLog.IJsonConverter originalConverter)
        {
            _originalConverter = originalConverter;
        }
    
        /// <summary>Serialization of an object into JSON format.</summary>
        /// <param name="value">The object to serialize to JSON.</param>
        /// <param name="builder">Output destination.</param>
        /// <returns>Serialize succeeded (true/false)</returns>
        public bool SerializeObject(object value, System.Text.StringBuilder builder)
        {
            if ( Convert.GetTypeCode(value) == TypeCode.Object
              && !(value is Exception)
              && !(value is IFormattable)
              && !(value is IEnumerable)
              && !value.GetType().IsValueType)
            {
                builder.Append("\"Type\": \"").Append(value.GetType().ToString()).Append("\" ");
            }
    
            return _originalConverter.SerializeObject(value, builder);
        }
    }
