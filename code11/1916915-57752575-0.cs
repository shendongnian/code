     <ListView
                x:Name="listView"
                ItemsSource="{Binding peoples}"
                SelectedItem="{Binding selecteditem}">
                <ListView.Header>
                    <Grid>
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition Width="*" />
                            <ColumnDefinition Width="*" />
                            <ColumnDefinition Width="*" />
                            <ColumnDefinition Width="*" />
                        </Grid.ColumnDefinitions>
                        <Grid.RowDefinitions>
                            <RowDefinition Height="Auto" />
                        </Grid.RowDefinitions>
                        <Label Grid.Column="0" Text="Id" />
                        <Label Grid.Column="1" Text="First Name" />
                        <Label Grid.Column="2" Text="Surname" />
                        <Label Grid.Column="3" Text="Date Of Birth" />
                    </Grid>
                </ListView.Header>
                <ListView.ItemTemplate>
                    <DataTemplate>
                        <ViewCell>
                            <Grid>
                                <Grid.ColumnDefinitions>
                                    <ColumnDefinition Width="*" />
                                    <ColumnDefinition Width="*" />
                                    <ColumnDefinition Width="*" />
                                    <ColumnDefinition Width="*" />
                                </Grid.ColumnDefinitions>
                                <Grid.RowDefinitions>
                                    <RowDefinition Height="Auto" />
                                </Grid.RowDefinitions>
                                <Label Grid.Column="0" Text="{Binding Id}" />
                                <Label Grid.Column="1" Text="{Binding FirstName}" />
                                <Label Grid.Column="2" Text="{Binding Surname}" />
                                <Label Grid.Column="3" Text="{Binding Age}" />
                            </Grid>
                        </ViewCell>
                    </DataTemplate>
                </ListView.ItemTemplate>
            </ListView>
    public class PersonViewModel:ViewModelBase
    {
        public ObservableCollection<personmodel> peoples { get; set; }
        private personmodel _selecteditem;
        public personmodel selecteditem
        {
            get { return _selecteditem; }
            set
            {
                _selecteditem = value;
                RaisePropertyChanged("selecteditem");
            }
        }     
        public PersonViewModel()
        {
            peoples = new ObservableCollection<personmodel>();
            peoples.Add(new personmodel { Id = Guid.NewGuid().ToString(), Age = 36, FirstName = "Andrew", Surname = "Smith" });
            peoples.Add(new personmodel { Id = Guid.NewGuid().ToString(), Age = 65, FirstName = "David", Surname = "White" });
            peoples.Add(new personmodel { Id = Guid.NewGuid().ToString(), Age = 39, FirstName = "Bert", Surname = "Edwards" });
            selecteditem = peoples[0];
        }
    }
    public class ViewModelBase: INotifyPropertyChanged
    {
       
        public event PropertyChangedEventHandler PropertyChanged;
      
        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
