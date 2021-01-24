    public class ClassA
    {
        public Color Color { get; set; }
    }
    public class ClassB
    {
        [TypeConverter(typeof(ExcludeColorTypeConverter)), ExcludeColor(Color.White,Color.Black)]
        public Color Color { get; set; }
    }
