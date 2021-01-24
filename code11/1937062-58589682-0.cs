csharp
public class CanvasPageViewModel : INotifyPropertyChanged
{
    private double _rectTop;
    public double RectTop
    {
        get => _rectTop;
        set
        {
            _rectTop = value;
            OnPropertyChanged();
        }
    }
    private double _rectLeft;
    public double RectLeft
    {
        get => _rectLeft;
        set
        {
            _rectLeft = value;
            OnPropertyChanged();
        }
    }
    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged([CallerMemberName]string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
**CanvasPage.xaml.cs**
csharp
public CanvasPageViewModel viewModel = new CanvasPageViewModel();
public CanvasPage()
{
    this.InitializeComponent();
    this.DataContext = viewModel;
    viewModel.RectTop = 20;
    viewModel.RectLeft = 100;
}
**CanvasPage.xaml**
xml
<Grid>
    <Canvas Width="500" Height="500" Background="White">
        <Rectangle Width="50" Height="50" Fill="Blue"
                   Canvas.Top="{Binding RectTop}"
                   Canvas.Left="{Binding RectLeft}"/>
    </Canvas>
</Grid>
This is a simple example. If you want to modify the position of the control later, you can directly modify the data source and the UI will synchronize.
Best regards.
