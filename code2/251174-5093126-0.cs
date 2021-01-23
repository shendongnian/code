        public object Deserialize<T>(System.IO.Stream serializationStream)
        {
            JsonSerializer serializer = new JsonSerializer();
            T instance;
            BsonReader reader = new BsonReader(serializationStream);
            instance = serializer.Deserialize<T>(reader);
            return instance;
        }
        public void Serialize(System.IO.Stream serializationStream, object graph)
        {
            JsonSerializer serializer = new JsonSerializer();
            using (BsonWriter writer = new BsonWriter(serializationStream))
            {
                serializer.Serialize(writer, graph);
            }
        }
