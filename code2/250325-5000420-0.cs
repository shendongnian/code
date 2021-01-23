    public class MyItemTypeCollection : CollectionBase
    {
        
        public MyItemType this[int Index]
        {
            get
            {
                return (MyItemType)List[Index];
            }
        }
    
        public bool Contains(MyItemType itemType)
        {
            return List.Contains(itemType);
        }
        public int Add(MyItemType itemType)
        {
            return List.Add(itemType);
        }
        public void Remove(MyItemType itemType)
        {
            List.Remove(itemType);
        }
        public void Insert(int index, MyItemType itemType)
        {
            List.Insert(index, itemType);
        }
        public int IndexOf(MyItemType itemType)
        {
           return List.IndexOf(itemType);
        }
}
