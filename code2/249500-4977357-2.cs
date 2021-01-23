    // Domain layer
    public class Word
    {
        public virtual int Id { get; set; }
        public virtual string Text { get; set; }
        public virtual IList<Word> Synonyms { get; set; }
        public virtual IList<Word> Antonyms { get; set; }
    }
    // Mapping layer
    public class WordMapping : ClassMap<Word>
    {
        public WordMapping()
	    {
            Id(x => x.Id).UnsavedValue(0);
            Map(x => x.Text);
            HasMany(x => x.Synonyms).Cascade.AllDeleteOrphan();
            HasMany(x => x.Antonyms).Cascade.AllDeleteOrphan();
        }
    }
    // Data access layer
    class Program : InMemoryDatabase
    {
        static void Main(string[] args)
        {
            using (var p = new Program())
            {
                // save some dummy data into the database
                var word = new Word
                {
                    Text = "myword",
                    Synonyms = new[]
                    {
                        new Word { Text = "synonym 1" },
                        new Word { Text = "synonym 2" },
                    }.ToList(),
                    Antonyms = new[]
                    {
                        new Word { Text = "antonym 1" },
                    }.ToList()
                };
                using (var tx = p.Session.BeginTransaction())
                {
                    p.Session.Save(word);
                    tx.Commit();
                }
                // and now let's query the database
                using (var tx = p.Session.BeginTransaction())
                {
                    var result = p.Session
                                  .QueryOver<Word>()
                                  .Where(w => w.Text == "myword")
                                  .SingleOrDefault();
                    var synonyms = result.Synonyms.Select(t => t.Text).ToArray();
                    Console.WriteLine("-- Synonyms --");
                    foreach (var item in synonyms)
                    {
                        Console.WriteLine(item);
                    }
                    var antonyms = result.Antonyms.Select(t => t.Text).ToArray();
                    Console.WriteLine("-- Antonyms --");
                    foreach (var item in antonyms)
                    {
                        Console.WriteLine(item);
                    }
                }
            }
        }
    }
    public abstract class InMemoryDatabase : IDisposable
    {
        private static Configuration _configuration;
        private static ISessionFactory _sessionFactory;
        protected ISession Session { get; set; }
        protected InMemoryDatabase()
        {
            _sessionFactory = CreateSessionFactory();
            Session = _sessionFactory.OpenSession();
            BuildSchema(Session);
        }
        private static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(SQLiteConfiguration.Standard.InMemory().ShowSql())
                .Mappings(M => M.FluentMappings.AddFromAssemblyOf<WordMapping>())
                .ExposeConfiguration(Cfg => _configuration = Cfg)
                .BuildSessionFactory();
        }
        private static void BuildSchema(ISession Session)
        {
            SchemaExport export = new SchemaExport(_configuration);
            export.Execute(true, true, false, Session.Connection, null);
        }
        public void Dispose()
        {
            Session.Dispose();
        }
    }
