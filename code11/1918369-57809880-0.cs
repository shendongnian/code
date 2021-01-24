    public sealed class Color: SmartEnum<Color>
    {
        public static readonly Color Red = new Color (nameof(Red), 1, 10.0f);
        public static readonly Color Yellow = new Color (nameof(Yellow), 2, 20.0f);
        public static readonly Color Green = new Color (nameof(Green), 3, 30.0f);
    
        private Color(string name, int value, double score) 
          : base(name, value)
        {
          this.Score = score;
        }
    
        public float Score {get;}
    }
    
    float TotalScore = Colors
      .Sum(color => color.Score);
