    public interface ITable<TItem>
        where TItem : IItem
    {
        IList<TItem> List();
        bool Add(TItem item);
        bool Delete(long itemId);
        bool Find(long itemId);
    }
