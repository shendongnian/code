    [JsonConverter(typeof(JsonConverter<Colour>))]
    public class Colour : StringEnumBase<Colour>
    {
        private Colour(string value) : base(value) { }
        public static Colour Red => new Colour("red");
        public static Colour Green => new Colour("green");
        public static Colour Blue => new Colour("blue");
    }
