    class MyObject
    {
        public int Number { get; }
        public MyObject(int number) => this.Number = number;
        public override string ToString() => this.Number.ToString();
    }
