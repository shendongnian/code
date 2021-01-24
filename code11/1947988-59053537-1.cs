    public class List1
    {
        public int cod { get; set; }
        public List<List2> list2 { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("l1-cod: " + cod);
            foreach(List2 l2 in list2)
            {
                sb.AppendLine(l2.ToString());
            }
            return sb.ToString();
        }
    }
    public class List2
    {
        public int cod { get; set; }
        public List<List3> list3 { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("\tl2-cod: " + cod);
            foreach (List3 l3 in list3)
            {
                sb.AppendLine("\t\t" + l3.ToString());
            }
            return sb.ToString();
        }
    }
    public class List3
    {
        public int cod { get; set; }
        public override string ToString()
        {
            return "l3-cod: " + cod;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<List1> listFather = new List<List1>();
            var listA = new List1() { cod = 1 };
            listA.list2 = new List<List2>();
            listA.list2.Add(new List2
            {
                cod = 1,
                list3 = new List<List3>(){
                new List3{cod = 1},
                new List3{cod = 2}
            },
            });
            listA.list2.Add(new List2
            {
                cod = 2,
                list3 = new List<List3>(){
                new List3{cod = 7},
                new List3{cod = 8},
                new List3{cod = 9}
            },
            });
            listA.list2.Add(new List2
            {
                cod = 2,
                list3 = new List<List3>(){
                new List3{cod = 7},
                new List3{cod = 9},
                new List3{cod = 9}
            },
            });
            listFather.Add(listA);
            var listB = new List1() { cod = 2 };
            listB.list2 = new List<List2>();
            listB.list2.Add(new List2
            {
                cod = 1,
                list3 = new List<List3>(){
                new List3{cod = 1},
                new List3{cod = 2}
            },
            });
            listB.list2.Add(new List2
            {
                cod = 2,
                list3 = new List<List3>(){
                new List3{cod = 7},
                new List3{cod = 8},
                new List3{cod = 10}
            },
            });
            listFather.Add(listB);
            var listC = new List1() { cod = 5 };
            listC.list2 = new List<List2>();
            listC.list2.Add(new List2
            {
                cod = 4,
                list3 = new List<List3>(){
                new List3{cod = 6},
                new List3{cod = 7}
            },
            });
            listC.list2.Add(new List2
            {
                cod = 2,
                list3 = new List<List3>(){
                new List3{cod = 7},
                new List3{cod = 8},
                new List3{cod = 10}
            },
            });
            listFather.Add(listC);
            var listD = new List1() { cod = 7 };
            listD.list2 = new List<List2>();
            listD.list2.Add(new List2
            {
                cod = 8,
                list3 = new List<List3>(){
                new List3{cod = 1},
                new List3{cod = 2}
            },
            });
            listD.list2.Add(new List2
            {
                cod = 2,
                list3 = new List<List3>(){
                new List3{cod = 7},
                new List3{cod = 9},
                new List3{cod = 1}
            },
            });
            listFather.Add(listD);
            Console.WriteLine("All objects:");            
            foreach(List1 l1 in listFather)
            {
                Console.WriteLine(l1);
            }
            Console.WriteLine("----------");
            // How can I get the List1 object,
            // where List2 children have cod = 2,
            // and List3 children have cod = 9.
            var matches = (from l1 in listFather
                          from l2 in l1.list2
                          from l3 in l2.list3
                          where l2.cod == 2 &&
                                l3.cod == 9
                          select l1).Distinct();
            Console.WriteLine("All matches:");
            foreach (List1 l1 in matches)
            {
                Console.WriteLine(l1);
            }
            Console.WriteLine();
            Console.Write("Press Enter to quit");
            Console.ReadLine();
        }
    }
