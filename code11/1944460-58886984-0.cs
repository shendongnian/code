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
