     <StackLayout>
            <CollectionView
                ItemsSource="{Binding customers}"
                SelectedItem="{Binding selecteditem}"
                SelectionMode="Single">
                <CollectionView.ItemTemplate>
                    <DataTemplate>
                        <StackLayout Orientation="Horizontal">
                            <Label Text="{Binding Name}" />
                            <Label Text="{Binding Age}" />
                        </StackLayout>
                    </DataTemplate>
                </CollectionView.ItemTemplate>
            </CollectionView>
            <Button
                x:Name="btn1"
                Clicked="Btn1_Clicked"
                Text="Get Index" />
        </StackLayout>
    public partial class Page2 : ContentPage, INotifyPropertyChanged
    {
        public ObservableCollection<customer> customers { get; set; }
        private customer _selecteditem;
        public customer selecteditem
        {
            get { return _selecteditem; }
            set
            {
                _selecteditem = value;
                RaisePropertyChanged("selecteditem");
            }
        }
        public Page2()
        {
            InitializeComponent();
            customers = new ObservableCollection<customer>()
            {
                new customer(){Name="cherry",Age=28},
                new customer(){Name="Wendy",Age=28},
                new customer(){Name="Jessie",Age=28},
                new customer(){Name="Barry",Age=28},
                new customer(){Name="Jason",Age=28},
                new customer(){Name="Annine",Age=28},
                new customer(){Name="Jack",Age=28},
                new customer(){Name="Leo",Age=28},
            };
            this.BindingContext = this;
        }
        private void Btn1_Clicked(object sender, EventArgs e)
        {
            var index = customers.IndexOf(selecteditem);
            Console.WriteLine("Current index is {0}",index);
        }
      
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
