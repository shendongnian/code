    class Card
    {
        public string CardType { get; set; }
        public string Name { get; set; }
        public int AddressIndex { get; set; }
        public int[] Entries { get; set; } = new int[8];
        public int[] AdditionalParameters { get; set; } = new int[8];
    }
