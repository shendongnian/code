    public class Person
    {
        public ObservableCollection<AccountDetail> Details { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    <Window.Resources>
        <CollectionViewSource x:Key="phonesSource" 
            Source="{StaticResource ResourceKey=WindowController}"  />
    </Window.Resources>
    <Grid>
        <ListBox 
            Name="PhonesListBox" 
            Margin="0,25,0,0" 
            HorizontalAlignment="Stretch" 
            VerticalAlignment="Top" 
            ItemsSource="{Binding Source={StaticResource phonesSource}}"
            HorizontalContentAlignment="Stretch" />
    </Grid>
    public MainWindow()
    {
        InitializeComponent();
        CollectionViewSource source = 
            (CollectionViewSource)FindResource("phonesSource");
        source.Filter += (o, e) =>
                {
                    if (((AccountDetail) e.Item).Type == DetailType.Phone)
                        e.Accepted = true;
                };
    }
