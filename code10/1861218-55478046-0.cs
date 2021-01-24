[
	{
		"ContextName": "Base rates",
		"Description": "Base rates description",
		"Indexes": {
			"SPX": {
				"2019-01-01T00:00:00Z": 2600.98
			},
			"NDX": {
				"2019-01-01T00:00:00Z": 6600.98
			}
		}
	}
]
Leaving the class structures updated as: 
**Context.cs**
public class Context
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("ContextName")]
        public string ContextName { get; set; }
        [BsonElement("Description")]
        public string Description { get; set; }
        [BsonElement("Indexes")]
        [BsonDictionaryOptions(DictionaryRepresentation.Document)]
        public Index Indexes { get; set; }
    }
**Index.cs**
public class Index : Dictionary<string, Dictionary<DateTime, double>> { }
I also changed the serializer to treat `DateTime` as a `string` instead, and so included this in the program startup:
BsonSerializer.RegisterSerializer(new DateTimeSerializer(DateTimeKind.Local, BsonType.String));
These changes allow the structure to be formatted correctly.
