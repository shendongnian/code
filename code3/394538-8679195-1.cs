    public class Level
    {
        public IList<Level> Parent { get; set; }
        public string Name { get; set; }
    }
    public class LevelCollection : Collection<Level>
    {
        protected override void InsertItem(int index, Level item)
        {
            base.InsertItem(index, item);
            item.Parent = this;
        }
        protected override void RemoveItem(int index)
        {
            this[index].Parent = null;
            base.RemoveItem(index);
        }
    }
