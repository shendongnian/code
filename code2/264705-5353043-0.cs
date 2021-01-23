    public interface IListItem
    {
        int MyProperty { get; set; }
    } 
    
    public class ListProvider
    {
        private IList<IListItem> _items = new List<IListItem>();
    
        public void AddListItem<T>(T listItem) where T : IListItem
        {
            _items.Add(listItem);
        }
    }
