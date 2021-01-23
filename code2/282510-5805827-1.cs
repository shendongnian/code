    class RandomColorSelector
    {
        static readonly Color[] Colors = 
            typeof(Color).GetProperties(BindingFlags.Public | BindingFlags.Static)
           .Select(propInfo => propInfo.GetValue(null, null))
           .Cast<Color>()
           .ToArray();
        static readonly string[] ColorNames =  
            typeof(Color).GetProperties(BindingFlags.Public | BindingFlags.Static)
            .Select(propInfo => propInfo.Name)
            .ToArray();
        
        private Random rand = new Random();
    
        static void Main(string[] args)
        {
            var colorSelector = new RandomColorSelector();
            var color = colorSelector.GetRandomColor();
            // in case you are only after the *name*
            var colorName = colorSelector.GetRandomColorName();            
        }
    
        public Color GetRandomColor()
        {
            return Colors[rand.Next(0, Colors.Length)];
        }
    
        public string GetRandomColorName()
        {
            return ColorNames[rand.Next(0, Colors.Length)];
        }
    }
