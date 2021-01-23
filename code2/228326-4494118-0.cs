    <Window x:Class="DependencyPropertyBindingDemo.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml" 
            xmlns:demo="clr-namespace:DependencyPropertyBindingDemo" 
            Title="MainWindow" Height="350" Width="525">
        <DockPanel>
            <demo:FilePicker x:Name="Picker"
                             DockPanel.Dock="Top"
                             Margin="5" /> 
            <TextBox DockPanel.Dock="Top" 
                    Text="{Binding ElementName=Picker, Path=FilePath}" />
            <TextBlock />
        </DockPanel>
    </Window>
    <UserControl x:Class="DependencyPropertyBindingDemo.FilePicker"
                 xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                 xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
        <DockPanel>
            <TextBox DockPanel.Dock="Left" 
                     Width="200"
                     Text="{Binding FilePath, UpdateSourceTrigger=PropertyChanged}" />
            <Button Width="50"
                    DockPanel.Dock="Left"
                    Command="{Binding Path=SaveCommand}">Save</Button>
            <TextBlock />
        </DockPanel>
    </UserControl>
    public partial class FilePicker : UserControl
    {
        public FilePicker()
        {
            SaveCommand = new FilePickerSaveCommand(this);
            DataContext = this;
            InitializeComponent();
        }
        public ICommand SaveCommand { get; set; }
        public static readonly DependencyProperty FilePathProperty = DependencyProperty.Register("FilePath", typeof(string), typeof(FilePicker));
        public string FilePath
        {
            get
            {
                return GetValue(FilePathProperty) as string;
            }
            set
            {
                SetValue(FilePathProperty, value);
            }
        }
    }
    public class FilePickerSaveCommand : ICommand
    {
        private FilePicker _FilePicker;
        public FilePickerSaveCommand(FilePicker picker)
        {
            _FilePicker = picker;
        }
        public void Execute(object parameter)
        {
            _FilePicker.FilePath = "Testing";
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public event EventHandler CanExecuteChanged;
    }
