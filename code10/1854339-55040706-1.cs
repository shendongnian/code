public MainWindow()
{
    InitializeComponent();
    var vm = new ViewModel();
    this.DataContext = vm;
    dgItemDisplay.SetBinding(DataGrid.ItemsSourceProperty, "Items");
    var col = new DataGridTextColumn();
    col.Binding = new Binding("ItemCode");
    dgItemDisplay.Columns.Add(col);
    var col2 = new DataGridTextColumn();
    col2.Binding = new Binding("ItemName");
    dgItemDisplay.Columns.Add(col2);
    var col3 = new DataGridTextColumn();
    col3.Binding = new Binding("ItemPrice");
    dgItemDisplay.Columns.Add(col3);
}
private void Button_Click(object sender, RoutedEventArgs e)
{
    ((ViewModel)this.DataContext).Items.Add(new Item() { ItemCode = "3", ItemName = "C", ItemPrice = 300 });
}
ViewModel and Items are as follows.
    public class ViewModel
    {
        public ObservableCollection<Item> Items { get; } = new ObservableCollection<Item>() {
            new Item() {ItemCode = "1", ItemName = "a", ItemPrice = 100 },
            new Item() {ItemCode = "2", ItemName = "b", ItemPrice = 200 },
        };
    }
    public class Item
    {
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public int ItemPrice { get; set; }
    }
If you don't call DataGrid.Columns.Add again when adding data, I think that it's not usual to increasing the number of columns.
