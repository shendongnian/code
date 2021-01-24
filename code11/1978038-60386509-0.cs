<ListView  ItemsSource="{Binding MyItems}">
            <ListView.ItemTemplate>
                <DataTemplate>
                    <ViewCell>
                        <Grid BackgroundColor="#eee" >
                            <Grid.RowDefinitions>
                                <RowDefinition Height="Auto" />
                                <RowDefinition Height="Auto" />
                            </Grid.RowDefinitions>
                            <Label Grid.Row="0" Text="{Binding Content}" TextColor="Red" />
                            <Picker Grid.Row="1" ItemsSource="{Binding PickerSource}" SelectedItem="{Binding SelectedValue}" />
                        </Grid>
                    </ViewCell>
                </DataTemplate>
            </ListView.ItemTemplate>
</ListView>
## in code behind
###in ViewModel
    public class MyViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public ObservableCollection<MyModel> MyItems { get; set; }
        public MyViewModel()
        {
            // I used local data just for demo, you could get it from DB
            MyItems = new ObservableCollection<MyModel>()
            {
                new MyModel(){Content="items1",PickerSource = new ObservableCollection<string>(){"option1","option2","option3" } },
                new MyModel(){Content="items2",PickerSource = new ObservableCollection<string>(){"option1","option2","option3" } },
                new MyModel(){Content="items3",PickerSource = new ObservableCollection<string>(){"option1","option2","option3" } },
                new MyModel(){Content="items4",PickerSource = new ObservableCollection<string>(){"option1","option2","option3" } },
                new MyModel(){Content="items5",PickerSource = new ObservableCollection<string>(){"option1","option2","option3" } },
                new MyModel(){Content="items6",PickerSource = new ObservableCollection<string>(){"option1","option2","option3" } },
                new MyModel(){Content="items7",PickerSource = new ObservableCollection<string>(){"option1","option2","option3" } },
            };
            foreach(var model in MyItems)
            {
                model.PropertyChanged += Model_PropertyChanged;
            }
        }
        private void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName== "SelectedValue")
            {
                var SelectedModel = sender as MyModel;
                var SelectedValue = SelectedModel.SelectedValue;
                //... do something you want 
            }
        }
    }
###in Model
    public class MyModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public ObservableCollection<string> PickerSource { get; set; }
        public string Content { get; set; }
        string selectedValue;
        public string SelectedValue
        {
            get { return selectedValue; }
            set
            {
                selectedValue = value;
                NotifyPropertyChanged("SelectedValue");
            }
        }
        //other properties
    }
