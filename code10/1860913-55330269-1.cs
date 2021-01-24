csharp
// Put this in MainWindow()
public MainWindow()
{
    InitializeComponent();
    new Demo(this);
}
csharp
// Demo code
public class Demo
{
    public Demo(FrameworkElement view)
    {
        View = view;
        View.DataContext = this;
        StartDemo();
    }
    private FrameworkElement View { get; }
    public ObservableCollection<Parent> Parents { get; } = new ObservableCollection<Parent>();
    public async void StartDemo()
    {
        var delay = 500;
        foreach (var index in Enumerable.Range(0, 5))
        {
            var item = new Parent { Name = $"Parent {index + 1}" };
            Parents.Add(item);
            await Task.Delay(delay);
        }
        // Add errors
        for (var i = 0; i < 3; i++)
        {
            Parents[1].Errors.Add(new Child { Name = $"Child {i + 1}" });
            await Task.Delay(delay);
        }
        // Remove errors
        while (Parents[1].Errors.Any())
        {
            Parents[1].Errors.RemoveAt(Parents[1].Errors.Count - 1);
            await Task.Delay(delay);
        }
        // Remove parents
        while (Parents.Any())
        {
            Parents.RemoveAt(Parents.Count-1);
            await Task.Delay(delay);
        }
    }
}
/// <summary>
/// Child (error item)
/// </summary>
public class Child
{
    public string Name { get; set; }
}
/// <summary>
/// Parent
/// </summary>
public class Parent : INotifyPropertyChanged
{
    public Parent()
    {
        System.Collections.Specialized.CollectionChangedEventManager.AddHandler(Errors,
            delegate
            {
                OnPropertyChanged(nameof(Status));
            });
    }
    private string _name;
    public string Name
    {
        get { return _name; }
        set { _name = value; OnPropertyChanged(); }
    }
    public string Status { get { return Errors.Any() ? "ERROR" : "OK"; } }
    /// <summary>
    /// Children/errors
    /// </summary>
    public ObservableCollection<Child> Errors { get; } = new ObservableCollection<Child>();
    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
xml
<!-- Xaml -->
<ItemsControl ItemsSource="{Binding Path=Parents}"
              Grid.IsSharedSizeScope="True">
    <ItemsControl.ItemTemplate>
        <DataTemplate DataType="{x:Type local:Parent}">
            <Grid>
                <Grid.ColumnDefinitions>
                    <ColumnDefinition Width="Auto" SharedSizeGroup="ParentColumn" />
                    <ColumnDefinition  />
                </Grid.ColumnDefinitions>
                <!-- Parent label -->
                <Label Content="{Binding Path=Name}"
                       x:Name="Label"/>
                <!-- Errors -->
                <ItemsControl ItemsSource="{Binding Path=Errors}"
                              Grid.Column="1">
                    <ItemsControl.ItemTemplate>
                        <DataTemplate DataType="{x:Type local:Child}">
                            <Label Content="{Binding Path=Name}"
                                   Background="Red" />
                        </DataTemplate>
                    </ItemsControl.ItemTemplate>
                    <ItemsControl.ItemsPanel>
                        <ItemsPanelTemplate>
                            <StackPanel Orientation="Horizontal" />
                        </ItemsPanelTemplate>
                    </ItemsControl.ItemsPanel>
                </ItemsControl>
            </Grid>
            <DataTemplate.Triggers>
                <!-- Parent is ok -->
                <DataTrigger Binding="{Binding Path=Status}"
                             Value="OK">
                    <Setter TargetName="Label" Property="Background" Value="Green" />
                </DataTrigger>
                
                <!-- Parent is not ok -->
                <DataTrigger Binding="{Binding Path=Status}"
                             Value="ERROR">
                    <Setter TargetName="Label" Property="Background" Value="Red" />
                </DataTrigger>
            </DataTemplate.Triggers>
        </DataTemplate>
    </ItemsControl.ItemTemplate>
</ItemsControl>
  [1]: https://i.stack.imgur.com/X4jeU.gif
  [2]: https://i.stack.imgur.com/L0lEk.gif
