	string json = "[{
			\"Department\": \"Department1\",
			\"JobTitle\": \"JobTitle1\",
			\"FirstName\": \"FirstName1\",
			\"LastName\": \"LastName1\"
		},{
			\"Department\": \"Department2\",
			\"JobTitle\": \"JobTitle2\",
			\"FirstName\": \"FirstName2\",
			\"LastName\": \"LastName2\"
		},
			{\"Skill\": \"Painter\",
			\"FirstName\": \"FirstName3\",
			\"LastName\": \"LastName3\"
		}]";
    
    List<Person> persons = 
        JsonConvert.DeserializeObject<List<Person>>(json, new PersonConverter());
    ...
    public class PersonConverter : JsonCreationConverter<Person>
    {
        protected override Person Create(Type objectType, JObject jObject)
        {
            if (FieldExists("Skill", jObject))
            {
                return new Artist();
            }
            else if (FieldExists("Department", jObject))
            {
                return new Employee();
            }
            else
            {
                return new Person();
            }
        }
        private bool FieldExists(string fieldName, JObject jObject)
        {
            return jObject[fieldName] != null;
        }
    }
    public abstract class JsonCreationConverter<T> : JsonConverter
    {
        /// <summary>
        /// Create an instance of objectType, based properties in the JSON object
        /// </summary>
        /// <param name="objectType">type of object expected</param>
        /// <param name="jObject">
        /// contents of JSON object that will be deserialized
        /// </param>
        /// <returns></returns>
        protected abstract T Create(Type objectType, JObject jObject);
        public override bool CanConvert(Type objectType)
        {
            return typeof(T).IsAssignableFrom(objectType);
        }
        public override object ReadJson(JsonReader reader, 
                                        Type objectType, 
                                         object existingValue, 
                                         JsonSerializer serializer)
        {
            // Load JObject from stream
            JObject jObject = JObject.Load(reader);
            // Create target object based on JObject
            T target = Create(objectType, jObject);
            // Populate the object properties
            serializer.Populate(jObject.CreateReader(), target);
            return target;
        }
        public override void WriteJson(JsonWriter writer, 
                                       object value,
                                       JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
