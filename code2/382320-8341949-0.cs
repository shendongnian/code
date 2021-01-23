    public class YourList : ObservableCollection<ItemsInGroup>
    {
        private static readonly string Groups = "#abcdefghijklmnopqrstuvwxyz";
        Dictionary<string, ItemsInGroup> groups = new Dictionary<string, ItemsInGroup>();
        public YourList()
        {
            foreach (char c in Groups)
            {
                ItemsInGroup group = new ItemsInGroup(c.ToString());
                this.Add(group);
                groups[c.ToString()] = group;
            }
        }
        public void AddItem(Item item)
        {
            string GroupKey = Item.GetSomeFieldKey(item);// a, b, etc.
            for (int i = 0; i < groups[GroupKey].Count; i++)
            {
                if (Item.CompareBySomeField(item, groups[GroupKey][i]) < 0)
                {
                    groups[Item.GetSomeFilesKey(item)].Insert(i, item);
                    return;
                }
            }
            groups[GroupKey].Add(item);
        }
    }
.
    public class ItemsInGroup : ObservableCollection<Item>, INotifyPropertyChanged
    {
        public ItemsInGroup(string category)
        {
            Key = category;
        }
        public string Key { get; set; }
        public bool HasItems { get { return Count > 0; } }
	//INotifyPropertyChanged implementation
