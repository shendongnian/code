    public enum Color { Red = 0, Green = 1, Blue = 2, Yellow = 3 }
    public static class ColorExtensions
    {
        public static string GetString(this Color color)
        {
            return string.Format("MyEnum({0})", color);
        }
    }
    Console.WriteLine("color value of 1 is " + ((Color)1).GetString());
