        class Program
    {
        static void Main(string[] args)
        {
            List<SoftClose> psc = new List<SoftClose>(){
                 new SoftClose(){ID=1, Status = "NO_CHANGE",AID=19, Prefix = "D1"},
                 new SoftClose(){ID=2, Status = "NO_CHANGE",AID=20, Prefix = "D2"},
                 new SoftClose(){ID=3, Status = "NO_CHANGE",AID=21, Prefix = "D3"},
                 new SoftClose(){ID=3, Status = "NO_CHANGE",AID=22, Prefix = "D9"}
                                                 };
            List<SoftClose> csc = new List<SoftClose>(){
                 new SoftClose(){ID=-1, Status = "NO_CHANGE",AID=19, Prefix = "D2"},
                 new SoftClose(){ID=-1, Status = "NO_CHANGE",AID=20, Prefix = "D2"},
                 new SoftClose(){ID=-1, Status = "NO_CHANGE",AID=21, Prefix = "D6"},
                 new SoftClose(){ID=-1, Status = "NO_CHANGE",AID=22, Prefix = "D4"},
                 new SoftClose(){ID=-1, Status = "NO_CHANGE",AID=23, Prefix = "D5"},
                 new SoftClose(){ID=-1, Status = "NO_CHANGE",AID=24, Prefix = "D3"}
                                                 };
            List<SoftClose> esc = new List<SoftClose>();
            Console.WriteLine("---------Previous List----------");
            foreach (var item in psc)
            {
                Console.WriteLine($"Id:{item.ID}, Desc1:{item.Prefix}, Status:{item.Status}");
            }
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("---------Current List----------");
            foreach (var item in csc)
            {
                Console.WriteLine($"Id:{item.ID}, Desc1:{item.Prefix}, Status:{item.Status}");
            }
            Console.WriteLine("--------------------------------------");
            var addlist = csc.Where(c => psc.All(p => !p.Prefix.Equals(c.Prefix)));
            foreach (var n in addlist)
            {
                var index = csc.FindIndex(p => p.Prefix.Equals(n.Prefix));
                csc[index].Status = "ADD";
                esc.Add(csc[index]);
            }
            var deletelist = psc.Where(p => p.Status.Equals("NO_CHANGE") && !csc.Exists(c => c.Prefix.Equals(p.Prefix)));
            foreach (var n in deletelist)
            {
                var index = psc.FindIndex(c => c.Prefix.Equals(n.Prefix));
                if (psc.FindIndex(c => c.Prefix.Equals(n.Prefix)) >= 0)
                {
                    psc[index].Status = "REMOVE";
                    esc.Add(psc[index]);
                }
            }
            Console.WriteLine("---------Effective List----------");
            foreach (var item in esc)
            {
                Console.WriteLine($"Id:{item.ID}, Prefix:{item.Prefix}, Status:{item.Status}");
            }
            Console.ReadLine();
        }
    }
    public class SoftClose
    {
        public int ID = -1;
        public int AID = -1;
        public int WFID = -1;
        public string Prefix;
        public DateTime SCDATE;
        public string Status;
    }
