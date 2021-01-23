    public class MainViewModel : ViewModelBase
    {
    ...
        private ObservableCollection<PartViewModel> _parts;
        public ObservableCollection<PartViewModel> Parts
        {
            get
            {
                if (_parts == null)
                {
                    _parts = new ObservableCollection<PartViewModel>();
                    _parts.CollectionChanged += _parts_CollectionChanged;
                }
                return _parts;
            }
        }
        object m_ReorderItem;
        int m_ReorderIndexFrom;
        void _parts_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Remove:
                    m_ReorderItem = e.OldItems[0];
                    m_ReorderIndexFrom = e.OldStartingIndex;
                    break;
                case NotifyCollectionChangedAction.Add:
                    if (m_ReorderItem == null)
                        return;
                    var _ReorderIndexTo = e.NewStartingIndex;
                    m_ReorderItem = null;
                    break;
            }
        }
        private PartViewModel _selectedItem;
        public PartViewModel SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                if (_selectedItem != value)
                {
                    _selectedItem = value;
                    RaisePropertyChanged("SelectedItem");
                }
            }
        }
       ...
 
        #region ViewModelBase
        public override void Cleanup()
        {
            if (_parts != null)
            {
                _parts.CollectionChanged -= _parts_CollectionChanged;
            }
            base.Cleanup();
        }
        #endregion
      }
    <Grid Background="{StaticResource ApplicationPageBackgroundThemeBrush}">
        <Grid.Resources>
            <CollectionViewSource x:Name="PartsCollection" Source="{Binding Parts}"/>
        </Grid.Resources>
        <ListView Margin="20" CanReorderItems="True" CanDragItems="True" AllowDrop="True" 
                  ItemsSource="{Binding Source={StaticResource PartsCollection}}" SelectedItem="{Binding SelectedItem, Mode=TwoWay}" SelectionMode="Single">
            <ListView.ItemContainerStyle>
                <Style TargetType="ListViewItem">
                    <Setter Property="HorizontalContentAlignment" Value="Stretch"></Setter>
                </Style>
            </ListView.ItemContainerStyle>
            <ListView.ItemTemplate>
            ...
            </ListView.ItemTemplate>
        </ListView>
    </Grid>
            
