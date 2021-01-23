    struct Package {
        public short First { get; private set; }
        public short Second { get; private set; }
        public byte Third { get; private set; }
        public Package(short first, short second, byte third) : this() {
            this.First = first;
            this.Second = second; 
            this.Third = third;
        }
    }
