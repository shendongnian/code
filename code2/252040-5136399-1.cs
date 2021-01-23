    public class NameCollection : System.Collections.ObjectModel.KeyedCollection<string, INamedObj>
    {
        protected override string GetKeyForItem(INamedObj item)
        {
            return item.Name;
        }
    }
