public partial class MainWindow : Window
{
    ObservableCollection<TestModel> testItem = new ObservableCollection<TestModel>();
    public MainWindow()
    {
        InitializeComponent();
        testItem.Add(new TestModel("Test_1"));
        testItem.Add(new TestModel("Test_2"));
        testItem.Add(new TestModel("Test_3"));
        LeftListBox.ItemsSource = testItem;
        CollectionViewSource.GetDefaultView(LeftListBox.ItemsSource).Filter = (tm) => !RightListBox.Items.Cast<TestModel>().Any(x => x.Equals(tm as TestModel));
    }
    private void Add_Button_Click(object sender, RoutedEventArgs e)
    {
        foreach (TestModel item in LeftListBox.SelectedItems)
            RightListBox.Items.Add(item);
        CollectionViewSource.GetDefaultView(LeftListBox.ItemsSource).Refresh();
    }
    private void Remove_Button_Click(object sender, RoutedEventArgs e)
    {
        foreach (TestModel item in RightListBox.SelectedItems.OfType<TestModel>().ToList())
            RightListBox.Items.Remove(item);
        CollectionViewSource.GetDefaultView(LeftListBox.ItemsSource).Refresh();
    }
}
However you should keep in mind that the ItemsSource of the LeftListBox always contains all the values, it is just visually filtered based on the Items in the right list.
If you wanted the ItemsSource of the LeftListBox and the RightListBox to change in relation to each other you should consider changing your xaml as below:
<ListBox
	x:Name="LeftListBox"
	Grid.Row="1"
	Grid.RowSpan="3"
	Grid.Column="0"
	DisplayMemberPath="TestItem"
	ItemsSource="{Binding LeftListBoxItems}"
	SelectionMode="Extended" />
<ListBox
	x:Name="RightListBox"
	Grid.Row="1"
	Grid.RowSpan="3"
	Grid.Column="2"
	DisplayMemberPath="TestItem"
	ItemsSource="{Binding RightListBoxItems}" />
and your code behind as below:
public partial class MainWindow : Window
{
    public ObservableCollection<TestModel> LeftListBoxItems { get; } = new ObservableCollection<TestModel>();
    public ObservableCollection<TestModel> RightListBoxItems { get; } = new ObservableCollection<TestModel>();
    public MainWindow()
    {
        InitializeComponent();
        DataContext = this;
        LeftListBoxItems.Add(new TestModel("Test_1"));
        LeftListBoxItems.Add(new TestModel("Test_2"));
        LeftListBoxItems.Add(new TestModel("Test_3"));
    }
    private void Add_Button_Click(object sender, RoutedEventArgs e)
    {
        foreach (TestModel item in LeftListBox.SelectedItems.OfType<TestModel>().ToList())
        {
            LeftListBoxItems.Remove(item);
            RightListBoxItems.Add(item);
        }
    }
    private void Remove_Button_Click(object sender, RoutedEventArgs e)
    {
        foreach (TestModel item in RightListBox.SelectedItems.OfType<TestModel>().ToList())
        {
            RightListBoxItems.Remove(item);
            LeftListBoxItems.Add(item);
        }
    }
}
