    sealed class Data
    {
        public string Serial { get; }
        public int    Amount { get; }
        public Data(string serial, int amount)
        {
            Serial = serial;
            Amount = amount;
        }
    }
