    class tag : IComparable<tag>
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public int TranslatedValue { get; set; }
        public int CompareTo(tag other)
        {
            if (other.Value > this.Value)
                return -1;
            if (other.Value < this.Value)
                return 1;
            return 0;
        }
        public override string ToString()
        {
            return string.Format("Id:{0}, Value: {1}, TranslatedValue: {2}", Id, Value, TranslatedValue);
        }
    }
