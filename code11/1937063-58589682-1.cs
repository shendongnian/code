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
---
**Update**
If you need to manually add child elements of Canvas, you can use this method:
csharp
var myRect = new Rectangle() 
{ 
    Height = 50, 
    Width = 100, 
    Fill = new SolidColorBrush(Colors.Blue)
};
myCanvas.Children.Add(myRect);
But if you want to bind the created Rectangle element, as you said, bind the `Canvas.Left` property, you can write:
csharp
public CanvasPageViewModel viewModel = new CanvasPageViewModel();
public CanvasPage()
{
    this.InitializeComponent();
    var myRect = new Rectangle() 
    { 
        Height = 50, 
        Width = 100, 
        Fill = new SolidColorBrush(Colors.Blue) 
    };
    Binding leftBinding = new Binding() 
    { 
        Path = new PropertyPath("RectLeft"),
        Mode=BindingMode.OneWay 
    };
    myRect.SetBinding(Canvas.LeftProperty, leftBinding);
    myCanvas.Children.Add(myRect);
}
Best regards.
