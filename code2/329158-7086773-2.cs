    public PivotPage1()
    {
        InitializeComponent();
        Loaded += (sender, e) =>
            {
                this.DataContext = App.ViewModel;
                var selectedItem = App.ViewModel.SelectedItem;
                var pi = ItemPivot.Items.First(p => p == selectedItem);
                ItemPivot.SelectedItem = pi;
            };
    }
