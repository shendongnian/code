        static void Main(string[] args)
        {
            
                Game Duel = new Game();
                Duel.Init("Level Eater", "Hand");
                Duel.Init("Junk Forward", "Hand");
                Duel.Init("Fusilier Dragon, the Dual-Mode Beast", "Hand");
                Matrix.Add(Duel);
                Game g1 = new Game((Game)Matrix[0].Clone());
                Console.WriteLine("g1:");
                g1.Print();
                Console.WriteLine();
                Console.WriteLine("Matrix[0]:");
                Matrix[0].Print();
                Console.WriteLine();
                Card c1 = g1.CardPool[0];
                if (g1.NormalSummon(ref c1))
                {
                    string s = "Normal Summon " + g1.CardPool[0].getName() + ".";
                    g1.ScenarioSteps.Add("dsqdqdqdq");
                    Console.WriteLine("After Normal Summon:");
                    Console.WriteLine("g1:");
                    g1.Print(); // Pointing to the same address!!!
                    Console.WriteLine();
                    Console.WriteLine("Matrix[0]:");
                    Matrix[0].Print(); // This changes, too!!!
                    Console.WriteLine();
                    Matrix.Add(g1);
                }
                g1 = new Game((Game)Matrix[0].Clone());
                if (Matrix[0].CardPool[0].IsLocation("Main Monster Zone")) Console.WriteLine("Yes, but I shouldn't be changed!");
                if (g1.CardPool[0].IsLocation("Main Monster Zone")) Console.WriteLine("Yes!");
                Card c2 = g1.CardPool[1];
                if (g1.NormalSummon(ref c2))
                {
                    string s = "Normal Summon " + g1.CardPool[1].getName() + ".";
                    g1.ScenarioSteps.Add(s);
                    g1.Print();
                    Console.WriteLine();
                    g1.CardPool[0].Print();
                    Console.WriteLine();
                    Matrix.Add(g1);
                }
                g1 = new Game((Game)Matrix[0].Clone());
                Card c3 = g1.CardPool[2];
                if (g1.NormalSummon(ref c3))
                {
                    string s = "Normal Summon " + g1.CardPool[2].getName() + ".";
                    g1.ScenarioSteps.Add(s);
                    g1.Print();
                    Console.WriteLine();
                    Matrix.Add(g1);
                }
                Console.WriteLine("Matrix Count: " + Matrix.Count);
                Console.ReadKey();
            
        }
    public class Game : ICloneable
    {
        public Game()
        {
            Card_ID = 1;
            EmptyMainMonsterZones = 5;
            EmptyExtraMonsterZones = 1;
            EmptySpellTrapZones = 5;
            LP = 8000;
            NormalSummons = 1;
            DrawnCards = 0;
            LastEvent = "";
            CardPool = new List<Card>();
            ScenarioSteps = new List<string>();
        }
        public Game(Game other)
        {
            Card_ID = other.Card_ID;
            EmptyMainMonsterZones = other.EmptyMainMonsterZones;
            EmptyExtraMonsterZones = other.EmptyExtraMonsterZones;
            EmptySpellTrapZones = other.EmptySpellTrapZones;
            LP = other.LP;
            NormalSummons = other.NormalSummons;
            DrawnCards = other.DrawnCards;
            LastEvent = other.LastEvent;
            //CardPool = new List<Card>(other.CardPool);
            CardPool = new List<Card>();
            foreach (Card c in other.CardPool)
            {
                CardPool.Add(c);
            }
            //ScenarioSteps = new List<string>(other.ScenarioSteps);
            ScenarioSteps = new List<string>();
            foreach (string s in other.ScenarioSteps)
            {
                ScenarioSteps.Add(s);
            }
        }
        int Card_ID;
        public int EmptyMainMonsterZones;
        public int EmptyExtraMonsterZones;
        public int EmptySpellTrapZones;
        public int LP;
        public int NormalSummons;
        public int DrawnCards;
        public string LastEvent;
        public List<Card> CardPool = new List<Card>();
        public List<string> ScenarioSteps = new List<string>();
        public void Init(string name, string location, string position = "-")
        {
            Card c = new Card(name);
            if (location == "Main Monster Zone")
            {
                c.SetLocation(location);
                EmptyMainMonsterZones--;
            }
            else if (location == "Extra Monster Zone")
            {
                c.SetLocation(location);
                EmptyExtraMonsterZones--;
            }
            else
            {
                c.SetLocation(location);
                c.SetPosition(position);
                c.SetCard_ID(Card_ID);
                Card_ID++;
                CardPool.Add(c);
            }
        }
        public void PrintScenarioSteps()
        {
            for (int i = 0; i < ScenarioSteps.Count; i++)
            {
                Console.WriteLine(ScenarioSteps[i]);
            }
        }
        public void Print()
        {
            for (int i = 0; i < CardPool.Count; i++)
            {
                if (!CardPool[i].IsLocation("No Location"))
                {
                    Console.WriteLine("{0} ({1}) is in the {2}", CardPool[i].getName(), CardPool[i].getLevel(), CardPool[i].getLocation());
                }
            }
        }
        // Checks
        bool IsCanBeNormalSummoned(Card c)
        {
            if (c.IsLevelBelow(4) && c.IsLocation("Hand") && EmptyMainMonsterZones > 0 && NormalSummons > 0) return true;
            if (c.IsException("Normal Summon without Tribute") && c.IsLocation("Hand") && EmptyMainMonsterZones > 0 && NormalSummons > 0) return true;
            return false;
        }
        // Operations
        public bool NormalSummon(ref Card c)
        {
            if (IsCanBeNormalSummoned(c))
            {
                c.SetPreviousLocation(c.getLocation());
                c.NormalSummoned = true;
                c.SetLocation("Main Monster Zone");
                EmptyMainMonsterZones--;
                NormalSummons--;
                LastEvent = "Normal Summon";
                if (!c.Negated)
                {
                    if (c.IsName("Fusilier Dragon, the Dual-Mode Beast"))
                    {
                        c.SetAttack(c.getAttack() / 2);
                        c.SetDefense(c.getDefense() / 2);
                    }
                }
                return true;
            }
            return false;
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
