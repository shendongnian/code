    [Serializable]
    public class MyTypeColl
    {
        public MyTypeColl()
        {
        }
        public List<MyType> Coll { get; set; }
    }
    [Serializable]
    public class MyType
    {
        private string test;
        public string Test
        {
            get { return this.test; }
            set { this.test = value; }
        }
        public MyType()
        {
        }
    }
    // save code
        MyTypeColl coll = new MyTypeColl();
        coll.Coll = new List<MyType>();
        coll.Coll.Add(new MyType{Test = "MyTest"});
        BinaryFormatter bf = new BinaryFormatter();
        using (FileStream stream = new FileStream("test.bin", FileMode.OpenOrCreate))
        {
            bf.Serialize(stream, coll);
        }
