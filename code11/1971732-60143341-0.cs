csharp
public class ViewModel : INotifyPropertyChanged
{
    // ... other code
    public List<InkStroke> Strokes { get; set; }
    public ViewModel()
    {
        Strokes = new List<InkStroke>();
    }
}
**2. Change the internal structure of `CanvasControl`**
**xaml**
xml
<Grid>
    <InkCanvas x:Name="inkCanvas" 
               Margin="0 2"
               MinWidth="1000" 
               MinHeight="300"
               HorizontalAlignment="Stretch" >
    </InkCanvas>
</Grid>
**xaml.cs**
csharp
public sealed partial class CanvasControl : UserControl
{
    public CanvasControl()
    {
        this.InitializeComponent();
        // Set supported inking device types.
        inkCanvas.InkPresenter.InputDeviceTypes =
            Windows.UI.Core.CoreInputDeviceTypes.Mouse |
            Windows.UI.Core.CoreInputDeviceTypes.Pen;
        
    }
    private void StrokesCollected(InkPresenter sender, InkStrokesCollectedEventArgs args)
    {
        if (Data != null)
        {
            var strokes = inkCanvas.InkPresenter.StrokeContainer.GetStrokes().ToList();
            Data.Strokes = strokes.Select(p => p.Clone()).ToList();
        }
    }
    public ViewModel Data
    {
        get { return (ViewModel)GetValue(DataProperty); }
        set { SetValue(DataProperty, value); }
    }
    public static readonly DependencyProperty DataProperty =
        DependencyProperty.Register("Data", typeof(ViewModel), typeof(CanvasControl), new PropertyMetadata(null,new PropertyChangedCallback(Data_Changed)));
    private static void Data_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if(e.NewValue!=null && e.NewValue is ViewModel vm)
        {
            var strokes = vm.Strokes.Select(p=>p.Clone());
            var instance = d as CanvasControl;
            instance.inkCanvas.InkPresenter.StrokesCollected -= instance.StrokesCollected;
            instance.inkCanvas.InkPresenter.StrokeContainer.Clear();
            try
            {
                instance.inkCanvas.InkPresenter.StrokeContainer.AddStrokes(strokes);
            }
            catch (Exception)
            {
                
            }
            
            instance.inkCanvas.InkPresenter.StrokesCollected += instance.StrokesCollected;
        }
    }
}
In this way, we can keep our entries stable.
Best regards.
