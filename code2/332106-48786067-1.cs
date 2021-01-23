    public static bool UnitTest()
    {
        const int testPairs = 512;
        var bitstream = new MemoryStream();
        var bitwriter = new BinaryBitWriter(bitstream);
        var bitreader = new BinaryBitReader(bitstream);
        byte[] bytes = new byte[] { 1, 2, 3, 4, 255 };
        byte Byte = 128;
        bool Bool = true;
        char[] chars = new char[] { 'a', 'b', 'c' };
        string str = "hello";
        var Float = 2.5f;
        ulong Ulong = 12345678901234567890;
        long Long = 1122334455667788;
        uint Uint = 1234567890;
        int Int = 999998888;
        ushort UShort = 12345;
        short Short = 4321;
        double Double = 9.9;
        char Char = 'A';
        sbyte Sbyte = -128;
        decimal Decimal = 10000.00001m;
        List<BBTest> pairs = new List<BBTest>();
        // Make pairs of write and read tests
        pairs.Add(new BBTest(Bool, (w) => w.Write(Bool), (r) => { if (r.ReadBoolean() != Bool) throw new Exception(); }));
        pairs.Add(new BBTest(bytes, (w) => w.Write(bytes, 0, 5), (r) => { if (arrayCompare(r.ReadBytes(5), bytes)) throw new Exception(); }));
        pairs.Add(new BBTest(Byte, (w) => w.Write(Byte), (r) => { if (r.ReadByte() != Byte) throw new Exception(); }));
        pairs.Add(new BBTest(chars, (w) => w.Write(chars, 0, 3), (r) => { if (arrayCompare(r.ReadChars(3), chars)) throw new Exception(); })); /////////////
        pairs.Add(new BBTest(str, (w) => w.Write(str), (r) => { string s; if ((s = r.ReadString()) != str) throw new Exception(); }));
        pairs.Add(new BBTest(Decimal, (w) => w.Write(Decimal), (r) => { if (r.ReadDecimal() != Decimal) throw new Exception(); }));
        pairs.Add(new BBTest(Float, (w) => w.Write(Float), (r) => { if (r.ReadSingle() != Float) throw new Exception(); }));
        pairs.Add(new BBTest(Ulong, (w) => w.Write(Ulong), (r) => { if (r.ReadUInt64() != Ulong) throw new Exception(); }));
        pairs.Add(new BBTest(Long, (w) => w.Write(Long), (r) => { if (r.ReadInt64() != Long) throw new Exception(); }));
        pairs.Add(new BBTest(Uint, (w) => w.Write(Uint), (r) => { if (r.ReadUInt32() != Uint) throw new Exception(); }));
        pairs.Add(new BBTest(Int, (w) => w.Write(Int), (r) => { if (r.ReadInt32() != Int) throw new Exception(); }));
        pairs.Add(new BBTest(UShort, (w) => w.Write(UShort), (r) => { if (r.ReadUInt16() != UShort) throw new Exception(); }));
        pairs.Add(new BBTest(Short, (w) => w.Write(Short), (r) => { if (r.ReadInt16() != Short) throw new Exception(); }));
        pairs.Add(new BBTest(Double, (w) => w.Write(Double), (r) => { if (r.ReadDouble() != Double) throw new Exception(); }));
        pairs.Add(new BBTest(Char, (w) => w.Write(Char), (r) => { if (r.ReadChar() != Char) throw new Exception(); })); ///////////////
        pairs.Add(new BBTest(bytes, (w) => w.Write(bytes), (r) => { if (arrayCompare(r.ReadBytes(5), bytes)) throw new Exception(); }));
        pairs.Add(new BBTest(Sbyte, (w) => w.Write(Sbyte), (r) => { if (r.ReadSByte() != Sbyte) throw new Exception(); }));
        // Now add all tests, and then a bunch of randomized tests, to make sure we test lots of combinations incase there is some offsetting error
        List<BBTest> test = new List<BBTest>();
        test.AddRange(pairs);
        var rnd = new Random();
        for (int i = 0; i < testPairs - test.Count; i++)
        {
            if (rnd.NextDouble() < 0.75)
                test.Add(pairs[0]);
            else
                test.Add(pairs[rnd.Next(pairs.Count)]);
        }
            
        // now write all the tests
        for (int i = 0; i < test.Count; i++)
            test[i].Writer(bitwriter);
        bitwriter.Flush();
        // now reset the stream and test to see that they are the same
        bitstream.Position = 0;
        for (int i = 0; i < test.Count; i++)
            test[i].ReadTest(bitreader);
        // As comparison, lets write the same stuff to a normal binarywriter and compare sized
        var binstream = new MemoryStream();
        var binwriter = new BinaryWriter(binstream);
        for (int i = 0; i < test.Count; i++)
            test[i].Writer(binwriter);
        binwriter.Flush();
        var saved = 1 - bitstream.Length / (float)binstream.Length;
        var result = $"BinaryBitWriter was {(saved * 100).ToString("0.00")}% cheaper than a normal BinaryWriter with random data";
        bool arrayCompare(IEnumerable a, IEnumerable b)
        {
            var B = b.GetEnumerator();
            B.MoveNext();
            foreach (var item in a)
            {
                if (item != B.Current)
                    return false;
                B.MoveNext();
            }
            return true;
        }
        return true;
    }
    delegate void writer(BinaryWriter w);
    delegate void reader(BinaryReader r);
    class BBTest
    {
        public object Object;
        public writer Writer;
        public reader ReadTest;
        public BBTest(object obj, writer w, reader r) { Object = obj; Writer = w; ReadTest = r; }
        public override string ToString() => Object.ToString();
    }
