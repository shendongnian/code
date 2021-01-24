namespace WpfApplication2
{
  public class ViewModel : INotifyPropertyChanged
  {
    private bool _isSelected;
    public ViewModel(int data)
    {
      Data = data;
    }
    public int Data { get; }
    public bool IsSelected
    {
      get { return _isSelected; }
      set
      {
        if (value == _isSelected) return;
        _isSelected = value;
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsSelected)));
      }
    }
    public event PropertyChangedEventHandler PropertyChanged;
  }
  public class ParentViewModel : INotifyPropertyChanged
  {
    private ViewModel _selectedViewModel;
    public ParentViewModel(List<ViewModel> viewModels)
    {
      ViewModels = viewModels;
      foreach (var vm in viewModels)
      {
        vm.PropertyChanged += (sender, args) =>
        {
          if (args.PropertyName != nameof(ViewModel.IsSelected)) return;
          SelectedViewModel = vm;
        };
      }
    }
    public ViewModel SelectedViewModel
    {
      get { return _selectedViewModel; }
      set
      {
        if (value == _selectedViewModel) return;
        _selectedViewModel = value;
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedViewModel)));
      }
    }
    public List<ViewModel> ViewModels { get; }
    public event PropertyChangedEventHandler PropertyChanged;
  }
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    private ParentViewModel _parentViewModel;
    public MainWindow()
    {
      InitializeComponent();
      var parentViewModel = new ParentViewModel(Enumerable.Range(1, 100).Select(x => new ViewModel(x)).ToList());
      _parentViewModel = parentViewModel;
      _parentViewModel.PropertyChanged += (sender, args) =>
      {
        if (args.PropertyName != nameof(ParentViewModel.SelectedViewModel)) return;
        var selectedViewModel = _parentViewModel.SelectedViewModel;
        if (selectedViewModel != null && selectedViewModel.IsSelected)
        {
          this.dataGrid.ScrollIntoView(selectedViewModel);
        }
      };
      dataGrid.ItemsSource = _parentViewModel.ViewModels;
    }
    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
      _parentViewModel.ViewModels[66].IsSelected = true;
    }
  }
}
**XAML**
<Window x:Class="WpfApplication2.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:WpfApplication2"
        mc:Ignorable="d"
        Title="MainWindow"
        Height="350"
        Width="525">
  <StackPanel Orientation="Horizontal">
    <DataGrid Name="dataGrid"
              EnableColumnVirtualization="True"
              EnableRowVirtualization="True">
      <DataGrid.RowStyle>
        <Style TargetType="DataGridRow">
          <Setter Property="IsSelected"
                  Value="{Binding IsSelected, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}" />
        </Style>
      </DataGrid.RowStyle>
    </DataGrid>
    <Button Click="ButtonBase_OnClick"
            Content="Click" />
  </StackPanel>
</Window>
