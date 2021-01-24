    public class ClassA
    {
        public Color Color { get; set; }
    }
    public class ClassB
    {
        [ExcludeColor(Color.White, Color.Black)]
        public Color Color { get; set; }
    }
