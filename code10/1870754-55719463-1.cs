       public partial class MainWindow : Window
            {
        
                public List<ItemDisplay> itemDisplayList { get; set; }
        
                public MainWindow()
                {
                    InitializeComponent();
        
                    this.DataContext = this;
        
                    itemDisplayList = new List<ItemDisplay>();
                    ItemDisplay itemDisplay = new ItemDisplay()
                    {
                        ItemCode = "1",
                        ItemName = "1",
                        ItemPrice = "1",
                        Quantity = "1",
                        itemSubDisplayList = new List<ItemSub>()
                    };
                    itemDisplay.itemSubDisplayList.Add(new ItemSub { ItemIdSub = "sa", ItemSubCode = "ran" });
                    itemDisplayList.Add(itemDisplay);
        
                    dgDisplay.ItemsSource = itemDisplayList;
        
                }
    
    
      public class ItemDisplay
        {
            public string ItemCode { get; set; }
            public string ItemPrice { get; set; }
            public string ItemName { get; set; }
            public string Quantity { get; set; }
            public List<ItemSub> itemSubDisplayList { get; set; }
        }
    
    
        public class ItemSub
        {
            public string ItemIdSub { get; set; }
            public string ItemSubCode { get; set; }
        }
