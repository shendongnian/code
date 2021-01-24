    class Model
    {
        public string Name { get; set; }
        public string Price { get; set; }
        public string Both => $"{Name},{Price}";
    }
