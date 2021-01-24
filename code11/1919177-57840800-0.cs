c#
public partial class MainWindow : INotifyPropertyChanged
{
    private ObservableCollection<myProcess> _processes;
    public ObservableCollection<myProcess> Processes
    {
        get { return _processes; }
        set
        {
            if (value.Equals(_processes))
                return;
            _processes = value;
            OnPropertyChanged(nameof(Processes));
        }
    }
    public MainWindow()
    {
        InitializeComponent();
        DataContext = this;
    }
    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        var processes = Process.GetProcesses();
        Processes = new ObservableCollection<myProcess>();
        foreach (var item in processes)
            Processes.Add(new myProcess { processName = item.ProcessName, processId = item.Id });
    }
    #region INotifyPropertyChanged
    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    #endregion
}
public class myProcess
{
    public string processName { get; set; }
    public int processId { get; set; }
}
MainWindow.xaml:
xaml
<ListView ItemsSource="{Binding Processes}">
    <ListView.View>
        <GridView>
            <GridViewColumn Header="Name" Width="200" DisplayMemberBinding="{Binding processName}" />
            <GridViewColumn Header="Id" Width="100" DisplayMemberBinding="{Binding processId}" />
        </GridView>
    </ListView.View>
</ListView>
Output:
[![enter image description here][1]][1]
  [1]: https://i.stack.imgur.com/r1gjI.jpg
