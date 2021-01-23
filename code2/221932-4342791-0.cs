    public class RandomColor
    {
        Random _random;
        public RandomColor()
        {
            _random = new Random();
        }
    
        public Color GetNext()
        {
            return Color.FromArgb(_random.Next(0, 255), _random.Next(0, 255), _random.Next(0, 255));
        }
    }
