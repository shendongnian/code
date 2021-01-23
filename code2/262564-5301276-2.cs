    class Program
    {
        static void Main(string[] args)
        {
            DummyObjectList dol = new DummyObjectList(2);
            dol.Add(new DummyObject("test1", (Decimal)25.36));
            dol.Add(new DummyObject("test2", (Decimal)0.698));
            XmlSerializer dolxs = new XmlSerializer(typeof(DummyObjectList));
            dolxs.Serialize(Console.Out, dol);
            Console.WriteLine(string.Empty);
            Console.WriteLine(string.Empty);
            List<DummyObject> dolist = new List<DummyObject>(2);
            dolist.Add(new DummyObject("test1", (Decimal)25.36));
            dolist.Add(new DummyObject("test2", (Decimal)0.698));
            XmlSerializer dolistxs = new XmlSerializer(typeof(List<DummyObject>));
            dolistxs.Serialize(Console.Out, dolist);
            Console.Read(); //  <--- Right here
        }
    }
