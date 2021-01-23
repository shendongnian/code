      <ListBox Name="listBoxDefaultAcc" HorizontalAlignment="Left" VerticalAlignment="Top" Width="450" Height="410">
                    <ListBox.ItemTemplate>
                        <DataTemplate>
                            <StackPanel Orientation="Horizontal" Height="60" Width="450">
                                <RadioButton Content="{Binding Name}" IsChecked="{Binding Selected, Mode=TwoWay}" GroupName="defaultAcc" HorizontalAlignment="Left" VerticalAlignment="Center" Height="80" Width="450" />
                            </StackPanel>
                        </DataTemplate>
                    </ListBox.ItemTemplate>
    public partial class Home : Page
    {
        public Home()
        {
            InitializeComponent();
            var items = new List<SomeClass>();
            items.Add(new SomeClass() {Name = "a"});
            items.Add(new SomeClass() {Name = "b"});
            items.Add(new SomeClass() {Name = "c"});
    
            listBoxDefaultAcc.ItemsSource = items;
        }
    
        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
    
        private void testButton_Click(object sender, RoutedEventArgs e)
        {
            var items = (List<SomeClass>)listBoxDefaultAcc.ItemsSource;
            var selectedItem = items.Where(x => x.Selected).FirstOrDefault();
        }
    
        class SomeClass
        {
            public string Name { get; set; }
            public bool Selected { get; set; }
        }
    }
