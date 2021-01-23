    public class MyRectangleConverter : JsonConverter
    {
        public override void WriteJson( JsonWriter writer, object value, JsonSerializer serializer )
        {
            var rectangle = (Rectangle)value;
            var obj = new { rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height };
            var t = JToken.FromObject( obj );
            var o = (JObject)t;
            o.WriteTo( writer );
        }
        public override object ReadJson( JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer )
        {
            var o = JObject.Load( reader );
            var x = o.Value<int>( "X" );
            var y = o.Value<int>( "Y" );
            var width = o.Value<int>( "Width" );
            var height = o.Value<int>( "Height" );
            return new Rectangle( x, y, width, height );
        }
        public override bool CanConvert( Type objectType )
        {
            throw new NotImplementedException();
        }
    }
