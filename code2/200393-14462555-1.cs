    public TestClass
    {
        public HInt32 HexaValue { get; set; }
    }
    public void SerializeClass()
    {
        TestClass t = new TestClass();
        t.HexaValue = 6574768; // Transparent int assigment
        XmlSerializer xser = new XmlSerializer(typeof(TestClass));
        StringBuilder sb = new StringBuilder();
        using(StringWriter sw = new StringWriter(sb))
        {
            xser.Serialize(sw, t);
        }
        Console.WriteLine(sb.ToString());
    }
