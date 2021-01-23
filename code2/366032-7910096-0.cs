    public class Test {
            public int A { get; set; }
            public string B { get; set; }
            public string C { get; set; }
        }
    
        public class TestR {
            public int A { get; set; }
            public string B { get; set; }
        }
    
        class Program
        {
            
            static void Main(string[] args)
            {
                List<Test> list = new List<Test>();
                list.Add(new Test { A=1, B="AAAAA", C="BBBBB"});
                list.Add(new Test { A = 2, B = "BBBBB", C = "CCCCC" });
                list.Add(new Test { A = 3, B = "CCCCC", C = "DDDDD" });
    
                List<TestR> r = new List<TestR>();
                list.ForEach(l=> r.Add(new TestR { A= l.A, B=l.B }));
                Console.ReadLine();
            }
        }
