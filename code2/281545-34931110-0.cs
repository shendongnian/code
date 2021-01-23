    /// <summary>
    /// Automagically convert known interfaces to (specific) concrete classes on deserialisation
    /// </summary>
    public class WithMocksJsonConverter : JsonConverter
    {
        /// <summary>
        /// The interfaces I know how to instantiate mapped to the classes with which I shall instantiate them, as a Dictionary.
        /// </summary>
        private readonly Dictionary<Type,Type> conversions = new Dictionary<Type,Type>() { 
            { typeof(IOne), typeof(MockOne) },
            { typeof(ITwo), typeof(MockTwo) },
            { typeof(IThree), typeof(MockThree) },
            { typeof(IFour), typeof(MockFour) }
        };
        /// <summary>
        /// Can I convert an object of this type?
        /// </summary>
        /// <param name="objectType">The type under consideration</param>
        /// <returns>True if I can convert the type under consideration, else false.</returns>
        public override bool CanConvert(Type objectType)
        {
            return conversions.Keys.Contains(objectType);
        }
        /// <summary>
        /// Attempt to read an object of the specified type from this reader.
        /// </summary>
        /// <param name="reader">The reader from which I read.</param>
        /// <param name="objectType">The type of object I'm trying to read, anticipated to be one I can convert.</param>
        /// <param name="existingValue">The existing value of the object being read.</param>
        /// <param name="serializer">The serializer invoking this request.</param>
        /// <returns>An object of the type into which I convert the specified objectType.</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            try
            {
                return serializer.Deserialize(reader, this.conversions[objectType]);
            }
            catch (Exception)
            {
                throw new NotSupportedException(string.Format("Type {0} unexpected.", objectType));
            }
        }
        /// <summary>
        /// Not yet implemented.
        /// </summary>
        /// <param name="writer">The writer to which I would write.</param>
        /// <param name="value">The value I am attempting to write.</param>
        /// <param name="serializer">the serializer invoking this request.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
