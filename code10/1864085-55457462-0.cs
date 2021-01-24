    // Use [BsonIgnoreExtraElements] attribute when not defining ALL fields in record
    internal class MainRecord
    {
        public ObjectId _id { get; set; }
        public List<ArrayItem> ResourceStatus { get; set; }
        // All the other fields here
    }
    // [BsonIgnoreExtraElements] as above
    internal class ArrayItem
    {
        public string E2EId { get; set; }
    }
