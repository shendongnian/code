    public class IJapaneseDictionaryEntry
    {
        public int Sequence { get; set; }
        public IEnumerable<IKanji> Kanjis { get; set; }
    }
    public class IKanji
    {
        public string Text { get; set; }
        public IEnumerable<Priority> Priorities { get; set; }
    }
    public class Priority
    {
        public string Value { get; set; }
    }
    public static void Main(string[] args)
    {
        // Initialize 3 objects. One has Priority we're searching
        List<IJapaneseDictionaryEntry> entries = new List<IJapaneseDictionaryEntry>()
        {
            new IJapaneseDictionaryEntry(){ Sequence = 1, Kanjis = new List<IKanji>() { new IKanji() { Priorities = new List<Priority>() { new Priority() { Value = "Frequency1" } } } } },
            new IJapaneseDictionaryEntry(){ Sequence = 2, Kanjis = new List<IKanji>() { new IKanji() { Priorities = new List<Priority>() { new Priority() { Value = "Frequency2" } } } } },
            new IJapaneseDictionaryEntry(){ Sequence = 3, Kanjis = new List<IKanji>() { new IKanji() { Priorities = new List<Priority>() { new Priority() { } } } } },
        };
        // Here's the magic:
        var filteredEntries = entries.Where( // Only entries
            e => e.Kanjis.Any( // which have one or more kanjis with..
                a => a.Priorities.Any( // which have one or more priorities                    p => p.Value == "Frequency1" // which have a value of "Frequency1"
                    )));
        // Let's check the output
        foreach (var e in filteredEntries)
        {
            Console.WriteLine(e.Sequence);
        }
    }
