    data.Where(a=>a.Sequence==2)
                           .SelectMany(b=>b.Senses.SelectMany(x=>x.Glosses.Where(g => g.Language == "German"))
                           .Select(y => new {b.Sequence,  y.Term}));
  -----
    public class JapaneseDictionaryEntry
    {
        private List<Sense> senses = new List<Sense>();
        public int Sequence { get; set; }
        public List<Sense> Senses { get { return senses; } set { senses = value; } }
    }
    public class Sense
    {
        private List<Gloss> glosses = new List<Gloss>();
        public List<Gloss> Glosses { get { return glosses; } set { glosses = value; } }
    }
    public class Gloss
    {
        public string Term { get; set; }
        public string Language { get; set; }
    }
    class Program
    {
        static List<JapaneseDictionaryEntry> GetData()
        {
            return new List<JapaneseDictionaryEntry>() {
                        new JapaneseDictionaryEntry()
                        {
                            Sequence = 1,
                            Senses = new List<Sense>() { new Sense() { Glosses = new List<Gloss>() {
                                new Gloss() { Term = "1",Language="English"},
                                new Gloss() { Term = "2",Language="German" },
                                new Gloss() { Term = "3",Language="German" },
                                new Gloss() { Term = "4",Language="English" }
                            }
                            } }
                        },
                        new JapaneseDictionaryEntry()
                        {
                            Sequence = 2,
                            Senses = new List<Sense>() { new Sense() { Glosses = new List<Gloss>() {
                                new Gloss() { Term = "a", Language="English"},
                                new Gloss() { Term = "b", Language="German" },
                                new Gloss() { Term = "c", Language="German" },
                                new Gloss() { Term = "d", Language="English"}
                            }
                            } }
                        }
                    };
        }
        static void Main(string[] args)
        {
            var data = GetData();
            var termData = data.Where(a=>a.Sequence==2)
                               .SelectMany(b=>b.Senses.SelectMany(x=>x.Glosses.Where(g => g.Language == "German"))
                               .Select(y => new {b.Sequence,  y.Term}));
            foreach (var item in termData)
            {
                Console.WriteLine(item);
            }
           
        }}
