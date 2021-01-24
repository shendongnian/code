csharp
public class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<ParentItem> ParentItems { get; set; }
        private ParentItem _selectedParentItem;
        public ParentItem SelectedParentItem
        {
            get { return _selectedParentItem; }
            set { SetProperty(ref _selectedParentItem, value); }
        }
        public MainWindowViewModel()
        {
            ParentItems = new ObservableCollection<ParentItem>();
            LoadDummyParentItems();
        }
        private ICommand _filterChildrenCommand;
        public ICommand FilterChildrenCommand => _filterChildrenCommand ?? (_filterChildrenCommand = new RelayCommand(param => FilterChildren((string)param), param => CanFilterChildren((string)param)));
        private bool CanFilterChildren(string filter) => SelectedParentItem != null && filter.Length > 0;
        private void FilterChildren(string filter)
        {
            CollectionViewSource.GetDefaultView(SelectedParentItem.ChildItems).Filter = item => (item as string).Contains(filter);
        }
        private void LoadDummyParentItems()
        {
            for (var i = 0; i < 20; i++)
            {
                ParentItems.Add(new ParentItem()
                {
                    Name = $"Parent Item {i}",
                    CreatedOn = DateTime.Now.AddHours(i),
                    IsActive = i % 2 == 0 ? true : false,
                    Status = i % 2 == 0 ? ParentItemStatus.Status_Two : ParentItemStatus.Status_One,
                    ChildItems = new List<string>() { $"Child one_{i}", $"Child two_{i}", $"Child three_{i}", $"Child four_{i}" }
                });
            }
        }
    }
**MainWindow.xaml.cs**:
csharp
public partial class MainWindow : Window
    {
        private readonly MainWindowViewModel _viewModel;
        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new MainWindowViewModel();
            this.DataContext = _viewModel;
        }
    }
**MainWindow.xaml**:
xaml
<Window x:Class="FilteringDemo.Views.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:FilteringDemo.Views"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="800">
    <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width=".25*"/>
            <ColumnDefinition Width=".75*"/>
        </Grid.ColumnDefinitions>
        <ListView x:Name="ItemList" Grid.Column="0" Margin="2" ItemsSource="{Binding ParentItems}" SelectedItem="{Binding SelectedParentItem, Mode=OneWayToSource}" SelectionMode="Single">
            <ListView.ItemTemplate>
                <DataTemplate>
                    <TextBlock Text="{Binding Name}"/>
                </DataTemplate>
            </ListView.ItemTemplate>
        </ListView>
        <Grid Grid.Column="1">
            <Grid.RowDefinitions>
                <RowDefinition Height="Auto"/>
                <RowDefinition Height="1*"/>
                <RowDefinition Height="Auto"/>
            </Grid.RowDefinitions>
            <Grid Grid.Row="0">
                <Grid.ColumnDefinitions>
                    <ColumnDefinition Width="1*"/>
                    <ColumnDefinition Width="1*"/>
                    <ColumnDefinition Width="1*"/>
                    <ColumnDefinition Width="1*"/>
                </Grid.ColumnDefinitions>
                <TextBlock Grid.Column="0" Text="{Binding ElementName=ItemList, Path=SelectedItem.Name}" Margin="2"/>
                <TextBlock Grid.Column="1" Text="{Binding ElementName=ItemList, Path=SelectedItem.CreatedOn}" Margin="2"/>
                <TextBlock Grid.Column="2" Text="{Binding ElementName=ItemList, Path=SelectedItem.IsActive}" Margin="2"/>
                <TextBlock Grid.Column="3" Text="{Binding ElementName=ItemList, Path=SelectedItem.Status}" Margin="2"/>
            </Grid>
            <ListView Grid.Row="1" Margin="2" ItemsSource="{Binding SelectedParentItem.ChildItems}" />
            
            <Grid Grid.Row="2">
                <Grid.ColumnDefinitions>
                    <ColumnDefinition Width="1*"/>
                    <ColumnDefinition Width="Auto"/>
                </Grid.ColumnDefinitions>
                <TextBox x:Name="ChildFilterInput" Grid.Column="0" Margin="2">
                    <TextBox.InputBindings>
                        <KeyBinding Command="{Binding FilterChildrenCommand}" CommandParameter="{Binding ElementName=ChildFilterInput, Path=Text}" Key="Return" />
                    </TextBox.InputBindings>
                </TextBox>
                <Button Grid.Column="1" Content="Filter" Width="100" Margin="2" Command="{Binding FilterChildrenCommand}" CommandParameter="{Binding ElementName=ChildFilterInput, Path=Text}"/>
            </Grid>
        </Grid>
    </Grid>
</Window>
**ViewModelBase.cs**:
csharp
public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (!EqualityComparer<T>.Default.Equals(field, newValue))
            {
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }
            return false;
        }
    }
**RelayCommand.cs**:
csharp
public class RelayCommand : ICommand
    {
        private Predicate<object> _canExecuteMethod;
        private Action<object> _executeMethod;
        public RelayCommand(Action<object> executeMethod, Predicate<object> canExecuteMethod = null)
        {
            _executeMethod = executeMethod;
            _canExecuteMethod = canExecuteMethod;
        }
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public bool CanExecute(object parameter)
        {
            return _canExecuteMethod == null ? true : _canExecuteMethod(parameter);
        }
        public void Execute(object parameter)
        {
            _executeMethod(parameter);
        }
    }
**ParentItem.cs**:
csharp
public class ParentItem
    {
        public string Name { get; set; }
        public List<string> ChildItems { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsActive { get; set; }
        public ParentItemStatus Status { get; set; }
    }
    public enum ParentItemStatus
    {
        Status_One,
        Status_Two
    }
**App.xaml**:
xaml
<Application x:Class="FilteringDemo.App"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:local="clr-namespace:FilteringDemo"
             StartupUri="Views/MainWindow.xaml">
    <Application.Resources>
         
    </Application.Resources>
</Application>
**Note:** The ```MainWindow.xaml``` file was moved into a "Views" folder, so I'm including the ```App.xaml``` with the updated StartupUri in case anyone is trying to copy and paste.
