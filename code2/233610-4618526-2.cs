    <StackPanel x:Name="LayoutRoot" Background="Transparent">
        <ListBox ItemsSource="{Binding Items}">
            <ListBox.ItemTemplate>
                <DataTemplate>
                    <StackPanel>
                        <TextBlock Text="{Binding}" />
                        <TextBlock Text="{Binding ElementName=LayoutRoot, Path=DataContext.Foo}" />
                    </StackPanel>
                </DataTemplate>
            </ListBox.ItemTemplate>
        </ListBox>
    </StackPanel>
    public partial class MainPage : UserControl
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            LayoutRoot.DataContext = this;
        }
        public string Foo
        {
            get
            {
                return "the moon";
            }
        }
        private int startIndex = 1;
        private IList<string> _data = new List<string>() { "foo", "bar", "baz" };
        public IList<string> Items
        {
            get
            {
                return _data;
            }
        }
    }
