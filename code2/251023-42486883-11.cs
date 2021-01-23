    public class Test
    {
        public Test() { }
        public Test(string name, string T2)
        {
            Name = name;
            t2 = T2;
        }
        [DisplayName("toto")]
        public string Name { get; set; }
        public string t2 { get; set; }
    }
