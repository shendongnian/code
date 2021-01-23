    public class Item
    {
        public int? Col1 { get; set; }
        public int? Col2 { get; set; }
        public int? Col3 { get; set; }
        private Timer Timer { get; set; }
        public List<Item> ParentList { get; set; }
        public Item()
        {
            Timer = new Timer();
            Timer.Callback += TimerCallBack();
            // Set timer timeout
            // start timer
        }
        public void AddToList(List<Item> parentList)
        {
            parentList.Add(this);
            ParentList = parentList;
        }
        public void TimerCallBack() 
        {
            if(!Col3.HasValue || !Col2.HasValue)
            {
                ParentList.Remove(this);
            }
        }
    }
    ....
    var list = new List<Item>();
    var item = new Item { /*Set your properties */  };
    item.AddToList(list);
