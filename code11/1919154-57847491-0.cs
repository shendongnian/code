csharp
public class TestIndex:INotifyPropertyChanged
{
    private int _index;
    public int Index
    {
        get => _index;
        set
        {
            _index = value;
            OnPropertyChanged();
        }
    }
    // other properties
    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged([CallerMemberName]string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
**converter.cs**
csharp
public class BackgroundConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if(value is int index)
        {
            // You can change color here.
            if (index % 2 == 0)
                return new SolidColorBrush(Colors.Red);
            else
                return new SolidColorBrush(Colors.Blue);
        }
        return new SolidColorBrush(Colors.Red);
    }
    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}
**xaml**
xml
<Page ...>
    <Page.Resources>
        <local:BackgroundConverter x:Key="BackgroundConverter"/>
        <DataTemplate x:Key="DefaultRow" x:DataType="local:TestIndex">
            <Grid Background="{x:Bind Index,Converter={StaticResource BackgroundConverter}, Mode=OneWay}" Height="50">
            </Grid>
        </DataTemplate>
    </Page.Resources>
    <Grid>
        <ListView ItemsSource="{x:Bind TestCollection}"
                  IsItemClickEnabled="True"
                  AllowDrop="True"
                  CanReorderItems="True"
                  IsSwipeEnabled="True"
                  ItemTemplate="{StaticResource DefaultRow}"
                  >
            <ListView.ItemContainerStyle>
                <Style TargetType="ListViewItem">
                    <Setter Property="HorizontalContentAlignment" Value="Stretch"/>
                    <Setter Property="VerticalContentAlignment" Value="Stretch"/>
                </Style>
            </ListView.ItemContainerStyle>
        </ListView>
    </Grid>
</Page>
**xaml.cs**
csharp
private ObservableCollection<TestIndex> TestCollection = new ObservableCollection<TestIndex>();
public ListViewPage()
{
    this.InitializeComponent();
    for (int i = 0; i < 10; i++)
    {
        TestCollection.Add(new TestIndex()
        {
            Index = i
        });
    }
    TestCollection.CollectionChanged += CollectionChanged;
}
private void CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
{
    for (int i = 0; i < TestCollection.Count; i++)
    {
        TestCollection[i].Index = i;
    }
}
This is because the `DragItemsCompleted` event is not triggered when you drag and drop items inside the ListView. Because it is essentially the deletion and addition of collection elements, you need to register the `CollectionChanged` event for the collection.
Best regards.
