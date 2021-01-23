    using System.Linq;
    
    IEnumerable<IEntry> func()
    {
        return new List<Entry>().Cast<IEntry>();
    }
