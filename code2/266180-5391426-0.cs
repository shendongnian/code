    public class Item
    {
        public string Name { get; set; }
    }
    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        RoomsListBox.ItemsSource = new[] { 
                                            new Item { Name = "First1" },
                                            new Item { Name = "First2" }};
        RoomsListBox.DisplayMemberPath = "Name";
    }
