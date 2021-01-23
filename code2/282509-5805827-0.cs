    class Program
    {
        static readonly Color[] colors = { Color.AliceBlue, Color.AntiqueWhite, ... };
        static Random rand = new Random();
    
        static void Main(string[] args)
        {
            var randomColor = colors[rand.Next(0, colors.Length)];
        }
    }
