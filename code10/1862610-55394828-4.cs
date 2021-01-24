    public partial class MainPage : ContentPage
        {
            ObservableCollection<ItemModel> allItems = new ObservableCollection<ItemModel>();
            List<ItemModel> selectedItems = new List<ItemModel>();
    
            public MainPage()
            {
                InitializeComponent();
                InitializeData();
                ProductsListView.ItemsSource = allItems;
            }
    
            private void reject(object sender, EventArgs e)
            {
                foreach (var v in selectedItems)
                {
                    allItems.Remove(v);
                }
                DisplayAlert("Rejected", "Request Rejected!!", "OK");
            }
    
            private void Switch_Toggled(object sender, ToggledEventArgs e)
            {
                var switch1 = (Switch)sender;
                var item = (ItemModel)switch1.BindingContext;
    
                var isSelected = !item.selected;
    
                if (isSelected)
                {
                    selectedItems.Add(item);
                }
                else
                {
                    selectedItems.Remove(item);
                }
            }
    
            private void InitializeData() {
                allItems.Add(new ItemModel { name = "Onion Rings, Medium",
                    retail_modified_item_id = 1000630,
                    old_price = 1.29,
                    new_price = 9.45,
                    selected = false
                });
    
                allItems.Add(new ItemModel
                {
                    name = "Hashbrowns",
                    retail_modified_item_id = 1000739,
                    old_price = 0.99,
                    new_price = 8.5,
                    selected = false
                });
    
                allItems.Add(new ItemModel
                {
                    name = "Amstel Light, Single",
                    retail_modified_item_id = 1002038,
                    old_price = 3.5,
                    new_price = 18,
                    selected = false
                });
    
            }
        }
