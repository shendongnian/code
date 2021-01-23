    public class test
    {
        public string aa { get; set; }
        public string bb { get; set; }
        public string cc { get; set; }
        public test AlterTest(Action<test> alteration)
        {
            alteration(this);
            return this;
        }
    }
    static void Main(string[] args)
    {
        var a = new test
        {
            aa = "a",
            bb = "b"
        };
        var d = a.AlterTest((t) => t.cc = "c");
    }
