    public class ItemWithCount
    {
       public Item Item { get; set; }
       public int Count
       {
            get { return Item.Count; }
            set { Item.Count = value; }
       }
    }
