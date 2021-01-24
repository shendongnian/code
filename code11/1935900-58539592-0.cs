<Window x:Class="WpfDataGridTest.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:i="http://schemas.microsoft.com/expression/2010/interactivity">
    <Grid>
        <DataGrid ItemsSource="{Binding Items}"
                  SelectedItem="{Binding SelectedItem}"
                  Name="grid">
            <i:Interaction.Triggers>
                <i:EventTrigger EventName="SelectionChanged">
                    <i:InvokeCommandAction Command="{Binding SelectionChangedCommand}" 
                                           CommandParameter="{Binding SelectedItems, ElementName=grid}"/>
                </i:EventTrigger>
            </i:Interaction.Triggers>
        </DataGrid>
    </Grid>
</Window>
**ViewModel:**
  public class MainViewModel
  {
    public MainViewModel(IEnumerable<Customer> customers)
    {
      Items = new ObservableCollection<Customer>(customers);
    }
    public ObservableCollection<Customer> Items { get; }
    public Customer SelectedItem { get; set; }
    public ICommand SelectionChangedCommand => _selectionChangedCommand ?? (_selectionChangedCommand = new RelayCommand<IList>(OnChanged));
    private void OnChanged(IList dataset)
    {
      var selectedItems = dataset.OfType<Customer>();
    }
    private ICommand _selectionChangedCommand;
  }
