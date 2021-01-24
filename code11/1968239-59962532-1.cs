    class Card
    {
        public string CardType { get; set; }
        public string Name { get; set; }
        public int AddressIndex { get; set; }
        public EntryParameterPair[] EntryParameterPairs { get; set; } = new EntryParameterPair[8];
    }
