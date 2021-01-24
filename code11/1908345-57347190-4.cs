    public class ItemsViewModel : BaseViewModel
    {
        private readonly IDatabase db;
        public ItemsViewModel( IDatabase database )
        {
            this.db = database ?? throw new ArgumentNullException(nameof(database));
            this.Items = new ObservableCollection<Item>();
        }
        public ObservableCollection<Item> Items { get; }
        public async Task LoadItemsAsync()
        {
            // (Show an activity indicator here and disable other inputs)
            this.Items.Clear();
            var items = await this.db.GetItemsAsync();
            this.Items.AddRange( items );
            // (Hide the activity indicator here)
        }
    }
