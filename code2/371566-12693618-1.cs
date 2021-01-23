        public struct EvilMutable
        {
            public int i;
        }
        public struct Tmd
        {
            public EvilMutable em;
        }
        public void DoIt(Tmd a)
        {
            a.em.i += 1;
        }
        public void DoIt(EvilMutable em)
        {
            em.i += 1;
        }
        public void Main()
        {
            Tmd a = new Tmd();
            a.em.i += 5;
            Console.WriteLine(a.em.i); // 5
            DoIt(a);
            Console.WriteLine(a.em.i); // 5 (unchanged)
            DoIt(a.em);
            Console.WriteLine(a.em.i); // 5 (unchanged)
        }
