    <Window x:Class="WpfApplication99.MainWindow"
            x:Name="GodWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            xmlns:view="clr-namespace:WpfApplication99.View"
            Title="MainWindow"
            xmlns:local="clr-namespace:WpfApplication99"
            DataContext="{Binding Vm, ElementName=GodWindow}">
        <StackPanel>
            <view:Test1 />
            <view:Test2 />
        </StackPanel>
    </Window>
    public partial class MainWindow : Window
    {
        ViewModel.GodViewModel _vm = new ViewModel.GodViewModel();
    
        public ViewModel.GodViewModel Vm
        {
            get { return _vm; }
            set { _vm = value; }
        }
    
        public MainWindow()
        {
            InitializeComponent();
        }
    }
