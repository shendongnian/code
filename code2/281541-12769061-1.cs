    class DTOJsonConverter : Newtonsoft.Json.JsonConverter
    {
        private static readonly string ISCALAR_FULLNAME = typeof(Interfaces.IScalar).FullName;
        private static readonly string IENTITY_FULLNAME = typeof(Interfaces.IEntity).FullName;
    
    
        public override bool CanConvert(Type objectType)
        {
            if (objectType.FullName == ISCALAR_FULLNAME
                || objectType.FullName == IENTITY_FULLNAME)
            {
                return true;
            }
            return false;
        }
    
        public override object ReadJson(Newtonsoft.Json.JsonReader reader, Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
        {
            if (objectType.FullName == ISCALAR_FULLNAME)
                return serializer.Deserialize(reader, typeof(DTO.ClientScalar));
            else if (objectType.FullName == IENTITY_FULLNAME)
                return serializer.Deserialize(reader, typeof(DTO.ClientEntity));
    
            throw new NotSupportedException(string.Format("Type {0} unexpected.", objectType));
        }
    
        public override void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
