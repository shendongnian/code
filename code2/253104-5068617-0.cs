    class Data // The main class to store data in
    {
        int x;
        public Data() { this.x = 0; }
        public int Number
        {
            get { return x; }
            set { x = value; }
        }
        public int Square
        {
            get { return x * x; }
            set { x = (int)Math.Sqrt(value); }
        }
        public void FromNumberStore(NumberMemento mem)
        {
            this.Number = mem.Number;
        }
        public void FromSqureStore(SquareMemento mem)
        {
            this.Square = mem.Square;
        }
    }
    [Serializable]
    class NumberMemento // memento #1
    {
        int x;
        public NumberMemento() { x = 0; }
        public NumberMemento(Data data)
        {
            this.x = data.Number;
        }
        public int Number
        {
            get { return x; }
            set { x = value; }
        }
    }
    [Serializable]
    class SquareMemento // memento #2
    {
        int x2;
        public SquareMemento() { x2 = 0; }
        public SquareMemento(Data data)
        {
            this.x2 = data.Square;
        }
        public int Square
        {
            get { return x2; }
            set { x2 = value; }
        }
    }
    class Program // Sample code to check all around serialization.
    {
        static void Main(string[] args)
        {
            Data store = new Data();
            store.Number = 9;
            {
                // Write and read based on number
                NumberMemento mem1 = new NumberMemento(store);
                BinaryFormatter bf1 = new BinaryFormatter();
                FileStream fs = new FileStream("numstore.dat", FileMode.Create);
                bf1.Serialize(fs, mem1);
                fs.Close();
                // clear data and deserialize
                store.Number = 0;
                fs = new FileStream("numstore.dat", FileMode.Open);
                mem1 = bf1.Deserialize(fs) as NumberMemento;
                fs.Close();
                store.FromNumberStore(mem1);
                // check store.Number == 9
            }
            {
                // Write and read based on square
                SquareMemento mem2 = new SquareMemento(store);
                BinaryFormatter bf2 = new BinaryFormatter();
                FileStream fs = new FileStream("sqrstore.dat", FileMode.Create);
                bf2.Serialize(fs, mem2);
                fs.Close();
                // clear data and deserialize
                store.Number = 0;
                fs = new FileStream("sqrstore.dat", FileMode.Open);
                mem2 = bf2.Deserialize(fs) as SquareMemento;
                fs.Close();
                store.FromSqureStore(mem2);
                // check store.Number == 9
            }
        }
    }
