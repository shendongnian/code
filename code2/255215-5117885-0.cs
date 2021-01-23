    class Program
    {
        static void Main(string[] args)
        {
            LocalizationEntry entry = new LocalizationEntry()
            {
                CatalogName = "Catalog",
                Identifier = "Id",
                Translations =
                {
                    { "PL", "jabłko" },
                    { "EN", "apple" },
                    { "DE", "apfel" }
                }
            };
            using (MemoryStream stream = new MemoryStream())
            {
                XmlSerializer serializer = new XmlSerializer(typeof(LocalizationEntry));
                serializer.Serialize(stream, entry);
                stream.Seek(0, SeekOrigin.Begin);
                LocalizationEntry deserializedEntry = (LocalizationEntry)serializer.Deserialize(stream);
                serializer.Serialize(Console.Out, deserializedEntry);
            }
        }
    }
    public class LocalizationEntry
    {
        public LocalizationEntry() { this.Translations = new TranslationCollection(); }
        public string CatalogName { get; set; }
        public string Identifier { get; set; }
        [XmlArrayItem]
        public TranslationCollection Translations { get; private set; }
    }
    public class TranslationCollection
        : Collection<Translation>
    {
        public TranslationCollection(params Translation[] items)
        {
            if (null != items)
            {
                foreach (Translation item in items)
                {
                    this.Add(item);
                }
            }
        }
        public void Add(string language, string text)
        {
            this.Add(new Translation
            {
                Language = language,
                Text = text
            });
        }
    }
    public class Translation
    {
        [XmlAttribute(AttributeName = "lang")]
        public string Language { get; set; }
        [XmlText]
        public string Text { get; set; }
    }
