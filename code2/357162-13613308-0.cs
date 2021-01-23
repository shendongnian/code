    public abstract class JsonDocument
    {
        /// <summary>
        /// The document type that the concrete class expects to be deserialized from.
        /// </summary>
        //[JsonProperty(PropertyName = "DocumentType")] // We substitute the DocumentType property with this ExpectedDocumentType property when serializing derived types.
        public abstract string ExpectedDocumentType { get; }
    
        /// <summary>
        /// The actual document type that was provided in the JSON that the concrete class was deserialized from.
        /// </summary>
        public string DocumentType { get; set; }
    
        //Tells json.net to not serialize DocumentType, but allows DocumentType to be deserialized
        public bool ShouldSerializeDocumentType()
        {
            return false;
        }
    }
