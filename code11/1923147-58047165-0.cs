csharp
public class ViewModel : ViewModelBase
{
    public Angle[] Angles
    {
        get => _angles;
        set => SetProperty(ref _angles, value);
    }
    public class Angle
    {
        public DateTime Date1 { get; set; }
        public double Value1 { get; set; }
        public double Value2 { get; set; }
        public DateTime Date2 { get; set; }
    }
}
code behind
csharp
public class ChartPage : Page
{
    private static readonly DependencyProperty AnnotationsProperty =
        DependencyProperty.RegisterAttached(
            "AnnotationsProperty",
            typeof(Angle[]),
            typeof(ChartPage),
            new PropertyMetadata(Array.Empty<Angle>(), OnAnnotationsChanged));
    public static void OnAnnotationsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var chart = (RadCartesianChart)d;
        var angles = e.NewValue as Angle[];
        chart.Annotations.Clear();
        if (angles == null || angles.Length == 0)
        {
            return;
        }
        angles
            .Select(x => new CartesianCustomLineAnnotation
            {
                HorizontalFrom = x.Date1,
                HorizontalTo = x.Date2,
                VerticalFrom = x.Value1,
                VerticalTo = x.Value2
            })
            .ToList()
            .ForEach(chart.Annotations.Add);
    }
    public ChartPage()
    {
            
        InitializeComponent();
        this.OhlcChart.SetBinding(AnnotationsProperty, new Binding
        {
            Path = new PropertyPath(nameof(ChartViewModel.Angles)),
            Mode = BindingMode.OneWay,
        });
    }
}
I hope this is the correct approach and doesn't memory leak.
