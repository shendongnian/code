    [Flags]
    public enum Priority
    {
         Frequency1 = 1,
         Frequency2 = 2,
         Frequency3 = 4,
         Frequency4 = 8
    }
    
    public interface IKanji
    {
        string Text { get; }
        IEnumerable<KanjiInformation> Informations { get; }
        Priority Priorities { get; }
    }
