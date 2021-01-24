    public class SingleOrArrayListItemConverter<TItem> : JsonConverter
    {
        // Adapted from the answers to https://stackoverflow.com/questions/18994685/how-to-handle-both-a-single-item-and-an-array-for-the-same-property-using-json-n
        // By Brian Rogers, dbc et. al.
        readonly JsonConverter itemConverter;
        readonly bool canWrite;
        public SingleOrArrayListItemConverter(Type itemConverterType) : this(itemConverterType, true) { }
        public SingleOrArrayListItemConverter(Type itemConverterType, bool canWrite)
        {
            this.itemConverter = (JsonConverter)Activator.CreateInstance(itemConverterType);
            this.canWrite = canWrite;
        }
        public override bool CanConvert(Type objectType)
        {
            return typeof(List<TItem>).IsAssignableFrom(objectType);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.MoveToContent().TokenType == JsonToken.Null)
                return null;
            var contract = serializer.ContractResolver.ResolveContract(objectType);
            var list = (ICollection<TItem>)(existingValue ?? contract.DefaultCreator());
            if (reader.TokenType != JsonToken.StartArray)
            {
                list.Add(ReadItem(reader, serializer));
                return list;
            }
            else
            {
                while (reader.ReadToContent())
                {
                    switch (reader.TokenType)
                    {
                        case JsonToken.EndArray:
                            return list;
                        default:
                            list.Add(ReadItem(reader, serializer));
                            break;
                    }
                }
                // Should not come here.
                throw new JsonSerializationException("Unclosed array at path: " + reader.Path);
            }
        }
        TItem ReadItem(JsonReader reader, JsonSerializer serializer)
        {
            if (itemConverter.CanRead)
                return (TItem)itemConverter.ReadJson(reader, typeof(TItem), default(TItem), serializer);
            else
                return serializer.Deserialize<TItem>(reader);
        }
        public override bool CanWrite { get { return canWrite; } }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var list = value as ICollection<TItem>;
            if (list == null)
                throw new JsonSerializationException(string.Format("Invalid type for {0}: {1}", GetType(), value.GetType()));
            if (list.Count == 1)
            {
                foreach (var item in list)
                    WriteItem(writer, item, serializer);
            }
            else
            {
                writer.WriteStartArray();
                foreach (var item in list)
                    WriteItem(writer, item, serializer);
                writer.WriteEndArray();
            }
        }
        void WriteItem(JsonWriter writer, TItem value, JsonSerializer serializer)
        {
            if (itemConverter.CanWrite)
                itemConverter.WriteJson(writer, value, serializer);
            else
                serializer.Serialize(writer, value);
        }
    }
    public class ConcreteConverter<IInterface, TConcrete> : JsonConverter where TConcrete : IInterface
    {
        //Taken from the answer to https://stackoverflow.com/questions/47939878/how-to-deserialize-collection-of-interfaces-when-concrete-classes-contains-other
        // by dbc
        public override bool CanConvert(Type objectType)
        {
            return typeof(IInterface) == objectType;
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return serializer.Deserialize<TConcrete>(reader);
        }
        public override bool CanWrite { get { return false; } }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
    public static partial class JsonExtensions
    {
        public static JsonReader MoveToContent(this JsonReader reader)
        {
            if (reader.TokenType == JsonToken.None)
                reader.Read();
            while (reader.TokenType == JsonToken.Comment && reader.Read())
                ;
            return reader;
        }
        public static bool ReadToContent(this JsonReader reader)
        {
            if (!reader.Read())
                return false;
            while (reader.TokenType == JsonToken.Comment)
                if (!reader.Read())
                    return false;
            return true;
        }
    }
