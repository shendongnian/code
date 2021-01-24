    public class ViewModel
    {
        private List<string> _comboBoxItems = new List<string> { "q", "w", "e", "r", "t", "y" };
        private List<ICollectionView> _comboBoxViews = new List<ICollectionView>();
        public ObservableCollection<string> Names { get; set; } = new ObservableCollection<string> { "111", "222", "333" };
        public ICollectionView ComboBoxView
        {
            get
            {
                var view = new CollectionViewSource { Source = _comboBoxItems}.View;
                _comboBoxViews.Add(view);
                view.MoveCurrentToPosition(-1);
                view.Filter = (x) => !_comboBoxViews.Where(y => y != view).Any(y => (string)y.CurrentItem == (string)x);
                view.CurrentChanged += (s, e) =>
                {
                    foreach (var v in _comboBoxViews.Where(x => x != view))
                        v.Refresh();
                };
                return view;
            }
        }
    }
    <ItemsControl ItemsSource="{Binding Names}" Grid.Row="1">
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <Grid>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="*"  />
                        <ColumnDefinition Width="*"  />
                    </Grid.ColumnDefinitions>
                    <Label  Content="{Binding}" Grid.Column="0" />
                    <ComboBox  ItemsSource="{Binding DataContext.ComboBoxView, RelativeSource={RelativeSource AncestorType=ItemsControl}}"
                               Grid.Column="1"/>
                </Grid>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
