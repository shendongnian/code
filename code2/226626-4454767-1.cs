    [Serializable]
    public struct MyType
    {
        private string test;
        public string Test
        {
            get { return this.test; }
            set { this.test = value; }
        }
    }
    // load code
        BinaryFormatter bf = new BinaryFormatter();
        using (FileStream stream = new FileStream("test.bin", FileMode.Open))
        {
            MyTypeColl coll = (MyTypeColl)bf.Deserialize(stream);
            Console.WriteLine(coll.Coll[0].Test);
        }
