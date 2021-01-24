    using System.Collections.ObjectModel;
    using System.Reflection;
    using System.Windows;
    
    namespace WpfApplication1
    {
    
        public partial class MainWindow : Window
        {
            private ObservableCollection<MyMenuItem> _windows = new ObservableCollection<MyMenuItem>();
    
            public MainWindow()
            {
                InitializeComponent();
    
                string ver = Assembly.GetExecutingAssembly().GetName().Version.ToString();
                Windows.Add(new MyMenuItem { Title = "Version" + ver });
            }
    
            public ObservableCollection<MyMenuItem> Windows
            {
                get { return _windows; }
                set { _windows = value; }
            }
        }
    
        public class MyMenuItem
        {
            public string Title { get; set; }
        }
    
    }
    
    <Window x:Class="WpfApplication1.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            Title="MainWindow" Height="233" Width="143" Name="UI">
        <Window.Resources>
            <CollectionViewSource Source="{Binding ElementName=UI, Path=Windows}" x:Key="MyMenuItems"/>
        </Window.Resources>
    
        <Grid DataContext="{Binding ElementName=UI}">
            <Menu Height="24" VerticalAlignment="Top">
                <MenuItem Header="_Version" >
                    <MenuItem Header="About">
                        <MenuItem.ItemsSource>
                            <CompositeCollection>
                                <CollectionContainer Collection="{Binding Source={StaticResource MyMenuItems}}" />
                                <MenuItem Header="Licensed To" />
                            </CompositeCollection>
                        </MenuItem.ItemsSource>
                        <MenuItem.ItemContainerStyle>
                            <Style>
                                <Setter Property="MenuItem.Header" Value="{Binding Title}"/>
                            </Style>
                        </MenuItem.ItemContainerStyle>
                    </MenuItem>
                </MenuItem>
            </Menu>
        </Grid>
      </Window>
