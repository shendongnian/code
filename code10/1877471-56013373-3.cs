    public class Data
    {
        public string Year { get; set; }
        public string City1 { get; set; }
        public string City2 { get; set; }
        public int Value { get; set; }
        public Data(string year, string city1, string city2, int value)
        {
            Year = year;
            City1 = city1;
            City2 = city2;
            Value = value;
        }
        public override string ToString()
        {
            return $"{Year} {City1} {City2} {Value}";
        }
    }
