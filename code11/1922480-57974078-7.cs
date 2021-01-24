      public class Test
        {
            public bool Val { get; set; }
            public bool Val1 { get; set; }
        }
    
        public class Test1
        {
            public List<Sub> sub { get; set; }
        }
        public class Sub
        {
            public string Val2 { get; set; }
            public string Val3 { get; set; }
        }
    
        public class RootObject
        {
            public string Units { get; set; }
            public List<Test> test { get; set; }
            public List<Test1> test1 { get; set; }
        }
