    [Serializable]
    class Data
    {
        public int Value { get; set; }
        public override bool Equals(object obj) => 
            (obj is Data data) ? data.Value == Value : false;
        public override int GetHashCode() => Value.GetHashCode();
    }
