    public class Score
    {
        public int Value { get; }
        public string Name { get; }
        
        public Score(int value, string name) => (Value, Name) = (value, name);
    }
