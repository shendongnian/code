    <viewModels:LocationsViewModel x:Key="viewModel" />
    .
    .
    .    
    <ListView
        DataContext="{StaticResource viewModel}"
        ItemsSource="{Binding Locations}"
        IsItemClickEnabled="True"
        ItemClick="GroupSection_ItemClick"
        ContinuumNavigationTransitionInfo.ExitElementContainer="True">
                       
        <ListView.ItemTemplate>
            <DataTemplate>
                <StackPanel Orientation="Horizontal">
                    <TextBlock Text="{Binding Name}" Margin="0,0,10,0" Style="{ThemeResource ListViewItemTextBlockStyle}" />
                    <TextBlock Text="{Binding Latitude, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}" Style="{ThemeResource ListViewItemTextBlockStyle}" Margin="0,0,5,0"/>
                    <TextBlock Text="{Binding Longitude, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}" Style="{ThemeResource ListViewItemTextBlockStyle}" Margin="5,0,0,0" />
                </StackPanel>
            </DataTemplate>
        </ListView.ItemTemplate>
    </ListView>
    public class LocationViewModel : BaseViewModel
    {
        ObservableCollection<Location> _locations = new ObservableCollection<Location>();
        public ObservableCollection<Location> Locations
        {
            get
            {
                return _locations;
            }
            set
            {
                if (_locations != value)
                {
                    _locations = value;
                    OnNotifyPropertyChanged();
                }
            }
        }
    }
    public class Location : BaseViewModel
    {
        int _locationId = 0;
        public int LocationId
        {
            get
            {
                return _locationId;
            }
            set
            {
                if (_locationId != value)
                {
                    _locationId = value;
                    OnNotifyPropertyChanged();
                }
            }
        }
        string _name = null;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnNotifyPropertyChanged();
                }
            }
        }
        float _latitude = 0;
        public float Latitude 
        { 
            get
            {
                return _latitude;
            }
            set
            {
                if (_latitude != value)
                {
                    _latitude = value;
                    OnNotifyPropertyChanged();
                }
            }
        }
        float _longitude = 0;
        public float Longitude
        {
            get
            {
                return _longitude;
            }
            set
            {
                if (_longitude != value)
                {
                    _longitude = value;
                    OnNotifyPropertyChanged();
                }
            }
        }
    }
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
        protected void OnNotifyPropertyChanged([CallerMemberName] string memberName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(memberName));
            }
        }
    }
