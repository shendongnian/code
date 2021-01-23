    class Data
    {
        ...
        Datum x;
        public Datum X { get { return x; } }
        public Data WithX(Datum x)
        {
            var newData = (Data)this.MemberwiseClone(); // <-- Shallow copy!
            newData.x = x;
            return newData;
        }
    }
            
