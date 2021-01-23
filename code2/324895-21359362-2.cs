    public class Sprite
    {
        [JsonConverter(typeof(MyRectangleConverter))]
        public Rectangle Rectangle;
    }
    public class MyRectangleConverter : JsonConverter
    {
        public override void WriteJson( JsonWriter writer, object value, JsonSerializer serializer )
        {
            var rectangle = (Rectangle)value;
            var obj = JObject.FromObject( new { rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height } );
            obj.WriteTo( writer );
        }
        public override object ReadJson( JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer )
        {
            var obj = JObject.Load( reader );
            var x = obj.Value<int>( "X" );
            var y = obj.Value<int>( "Y" );
            var width = obj.Value<int>( "Width" );
            var height = obj.Value<int>( "Height" );
            return new Rectangle( x, y, width, height );
        }
        public override bool CanConvert( Type objectType )
        {
            throw new NotImplementedException();
        }
    }
