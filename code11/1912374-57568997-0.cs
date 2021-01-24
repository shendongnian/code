    public class BasicItem
    {
        public int BasicItemID { get; set; }
        public string Name { get; set; }
        public int FoodItemID { get; set; }
        [ForeignKey("FoodItemID")]
        public FoodItem FoodItem { get; set; }
        public int LocalItemID { get; set; }
        [ForeignKey("LocalItemID")]
        public LocalItem LocalItem { get; set; }
    }
    public class FoodItem
    {
        public int FoodItemID { get; set; }
        public string Name { get; set; }
        //public int BasicItemID { get; set; }
        public BasicItem BasicItem { get; set; }
    }
    public class LocalItem
    {
        public int LocalItemID { get; set; }
        public string Name { get; set; }
        //public int BasicItemID { get; set; }
        public BasicItem BasicItem { get; set; }
    }
    public class ItemModel
    {
        public BasicItem BasicItem;
        public FoodItem FoodItem;
        public LocalItem LocalItem;
        public ItemModel()
        {
            BasicItem = new BasicItem();
            FoodItem = new FoodItem();
            LocalItem = new LocalItem();
        }
    }
