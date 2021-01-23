        public class GeometryConverter : JsonConverter
        {
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null)
                    return null;
                reader.Read(); // startobject
                //we should be at geometry type property now
                if ((string)reader.Value != "geometryType") throw new InvalidOperationException();
                reader.Read(); //propertyName
                var type = (string)reader.Value;
                Geometry value;
                switch(type)
                {
                    case "esriGeometryPolygon":
                        value = new PolygonGeometry();
                        break;
                    case "esriGeometryOther":
                        value = new OtherGeometry();
                        break;
                    default:
                        throw new NotSupportedException();
                }
                reader.Read(); // move to inner object property
                //should probably confirm name here
                reader.Read(); //move to inner object
                serializer.Populate(reader, value);
                reader.Read(); //move outside container (should be end object)
                return value;
            }
            public override bool CanConvert(Type objectType)
            {
                return typeof(Geometry).IsAssignableFrom(objectType);
            }
        }
        [JsonConverter(typeof(GeometryConverter))]
        public class OtherGeometry : Geometry
        {
        }
        [JsonConverter(typeof(GeometryConverter))]
        public class PolygonGeometry : Geometry
        {
        }
        [JsonConverter(typeof(GeometryConverter))]
        public class Geometry
        {
            public int rings { get; set; }
        }
