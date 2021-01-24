    class BaseClass
    {
        public List<ItemList> itemList = new List<ItemList>();
        public ListInfo listInfo = new ListInfo();
    }
    class ItemList
    {
        public string id { get; set; }
        public string name { get; set; }
    }
    class ListInfo
    {
        public string info1 { get; set; }
        public string info2 { get; set; }
    }
