    public struct MyData
    {
        public int Num;
        public int Number;
        public string Name;
        public string Url;
    };
    class XMLIgnore
    {
        static void SaveToXml(MyData obj)
        {
            XmlSerializer writer2 = customserialiser(obj);
            writer2.Serialize(Console.Out, obj);
        }
        static public XmlSerializer customserialiser(MyData d)
        {
            XmlAttributes attrs = new XmlAttributes();
            attrs.XmlIgnore = true;
            XmlAttributeOverrides xmlOveride = new XmlAttributeOverrides();
            if( d.Name.Length != 0 )
                xmlOveride.Add(typeof(MyData), "Url", attrs);
            else
                xmlOveride.Add(typeof(MyData), "Name", attrs);
            if (d.Num != 0)
                xmlOveride.Add(typeof(MyData), "Number", attrs);
            else
                xmlOveride.Add(typeof(MyData), "Num", attrs);
            return new XmlSerializer(typeof(MyData), xmlOveride);
        }
        public static void go()
        {
            MyData d = new MyData();
            d.Num = 1;
            d.Number = 2;
            d.Name = "John";
            d.Url = "Happy";
            SaveToXml(d);
            Console.WriteLine();
            Console.WriteLine();
            MyData d2 = new MyData();
            d2.Num = 0;
            d2.Number = 2;
            d2.Name = "";
            d2.Url = "Happy";
            SaveToXml(d2);
        }
    }
