	public partial class ItemSelectListView : ContentView
	{
        public static readonly BindableProperty ItemListViewProperty=
            BindableProperty.Create("ItemListView", typeof(IEnumerable<Item>), typeof(ItemSelectListView), default(Item));
        public IEnumerable<Item> ItemListView
        {
            get { return (IEnumerable<Item>)GetValue(ItemListViewProperty); }
            set { SetValue(ItemListViewProperty, value); }
        }
        public static readonly BindableProperty TitleLabelProperty =
            BindableProperty.Create("TitleLabel", typeof(string), typeof(ItemSelectListView), default(string));
        public string TitleLabel
        {
            get { return (string)GetValue(TitleLabelProperty); }
            set { SetValue(TitleLabelProperty, value); }
        }
        public event EventHandler<SelectedItemChangedEventArgs> ItemSelected;
        public void NotifyItemSelected(object sender, SelectedItemChangedEventArgs e)
        {            
            ItemSelected(sender, e);
        }
            public ItemSelectListView ()
		{
			InitializeComponent ();
            ItemsListView.SetBinding(ListView.ItemsSourceProperty, new Binding("ItemListView", source: this));
            Title.SetBinding(Label.TextProperty, new Binding("TitleLabel", source: this));
            ItemsListView.ItemSelected += NotifyItemSelected;
            ItemsListView.SetBinding(ListView.SelectedItemProperty, new Binding("ItemSelected", source: this));
        }
    }
