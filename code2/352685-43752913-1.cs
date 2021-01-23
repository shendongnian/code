    public sealed class Colors : EnumBase
    {
        public static readonly Colors Red = new Colors(0, "Red");
        public static readonly Colors Green = new Colors(1, "Green");
        public static readonly Colors Blue = new Colors(2, "Blue");
        public static readonly Colors Yellow = new Colors(3, "Yellow");
        public Colors(int v, string d) : base(v, d)
        {
        }
        static Colors()
        {
            BuildDictionary<Colors>();
        }
    }
