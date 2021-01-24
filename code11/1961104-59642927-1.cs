    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<Item> items = new List<Item>();
            items.Add(new Item() { Name = "Item1", Category = "Category_1" });
            items.Add(new Item() { Name = "Item2", Category = "Category_1" });
            items.Add(new Item() { Name = "Item3", Category = "Category_1" });
            items.Add(new Item() { Name = "Item4", Category = "Category_2" });
            items.Add(new Item() { Name = "Item5", Category = "Category_2" });
            ListCollectionView lcv = new ListCollectionView(items);
            lcv.GroupDescriptions.Add(new PropertyGroupDescription("Category"));
            //this.comboBox.ItemsSource = lcv;
            this.cboGroup.ItemsSource = lcv;
        }
        public class Item
        {
            public string Name { get; set; }
            public string Category { get; set; }
        }
    }
