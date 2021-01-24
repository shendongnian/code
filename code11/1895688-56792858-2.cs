XAML
<Window.Resources>
    <DataTemplate x:Key="TabListViewItemTemplate">
        <DockPanel LastChildFill="False">
            <TextBlock Text="{Binding TabText}" DockPanel.Dock="Left" />
            <Button x:Name="TabCloseButton" Click="TabCloseButton_Click" DockPanel.Dock="Right" >
                <Button.Template>
                    <ControlTemplate TargetType="Button">
                        <materialDesign:PackIcon 
                            Kind="Close" Foreground="White" 
                            VerticalAlignment="Center" HorizontalAlignment="Center" 
                            Width="20" Height="20" />
                    </ControlTemplate>
                </Button.Template>
            </Button>
        </DockPanel>
    </DataTemplate>
</Window.Resources>
<Grid>
    <ListView
        ItemsSource="{Binding TabItems}"
        ItemTemplate="{StaticResource TabListViewItemTemplate}"
        HorizontalContentAlignment="Stretch"
        />
</Grid>
MainWindow.xaml.cs
C#
public MainWindow()
{
    InitializeComponent();
    DataContext = new MainViewModel
    {
        TabItems = {
            new TabData { TabText = "Fred" },
            new TabData { TabText = "Ginger" },
            new TabData { TabText = "Herman" },
        }
    };
}
private void TabCloseButton_Click(object sender, RoutedEventArgs e)
{
    if ((sender as FrameworkElement).DataContext is TabData tabData)
    {
        MessageBox.Show($"TabCloseButton_Click() {tabData.TabText}");
    }
}
The TabData class. Don't inherit from UIElement. It's not an element in the user interface, it's just a plain C# class. If you were going to let the user edit TabText, you would make it a viewmodel that implements INotifyPropertyChanged. 
C#
    public class TabData
    {
        public string TabText { get; set; }
    }
The main viewmodel. Nothing we're doing here actually requires INotifyPropertyChanged on any of your classes, but you'll need it if you turn this into anything useful, so we'll include it. 
C#
public class ViewModelBase : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propName = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
}
public class MainViewModel : ViewModelBase
{
    public ObservableCollection<TabData> TabItems { get; } = new ObservableCollection<TabData>();
}
