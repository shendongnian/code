    public class Sprite
    {
        [JsonConverter(typeof(MyRectangleConverter))]
        public Rectangle Rectangle;
    }
