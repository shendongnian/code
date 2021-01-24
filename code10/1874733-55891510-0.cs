    class Demo
    {
        public int Key { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return ObjectDumper.Dump(this, DumpStyle.Console);
        }
    }
    var demo = new Demo() { Key = 1, Name = "Foo" };
    Console.WriteLine(demo.ToString());
