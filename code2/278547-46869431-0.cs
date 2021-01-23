    using System.Linq;
    
    public int countItems<T>(List<T> Items)
    {
        return Items.OfType<Something>().Where(thing => thisOneCounts(thing)).Count();
    }
