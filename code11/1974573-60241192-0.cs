c#
Observable
.FromEventPattern<EventArgs>(MapView, nameof(ViewpointChanged));
.Throttle(TimeSpan.FromMilliSeconds(300));
.Subscribe(eventPattern => vm.UpdateMapItems(eventPattern.Sender.VisibleArea.Extent));
When using `FromEventPattern` we're mapping events to instances of [EventPattern](https://docs.microsoft.com/en-us/previous-versions/dotnet/reactive-extensions/hh229009%28v%3dvs.103%29), which includes the `Sender` (source) of the event.
I tested by subscribing to a `UIElement`'s `PointerMoved` event. Which triggers `HandleEvent` multiple times if we keep moving. With `Throttle`, however, the event handler is executed only once. This is when the interval has passed *after* we stop moving.
MainPage.xaml
xaml
<Page
    x:Class="..."
    ...
    >
    <Grid>
        <Button x:Name="MyUIElement" Content="Throttle Surface"
                Height="250" Width="250" HorizontalAlignment="Center"/>
    </Grid>
</Page>
MainPage.xaml.cs
c#
public sealed partial class MainPage : Page
{
    public MainPage()
    {
        this.InitializeComponent();
        Observable
            .FromEventPattern<PointerRoutedEventArgs>(MyUIElement, nameof(UIElement.PointerMoved))
            .Throttle(TimeSpan.FromMilliseconds(300))
            .Subscribe(eventPattern => HandleEvent(eventPattern.Sender, eventPattern.EventArgs));
    }
    private void HandleEvent(object source, PointerRoutedEventArgs args)
    {
        Debug.WriteLine("Pointer Moved");
    }
}
2. Something custom
Our custom `Throttle` class keeps track of the last `sender` and `args` that have been processed. Processed as in "passed to `Throttle` for processing". Only when the timer elapses, and no other events have occurred, is the `eventHandler` (passed as a constructor argument) actually executed.
c#
public class Throttle<TEventArgs>
{
    private readonly DispatcherTimer _timer;
    private object _lastSender;
    private TEventArgs _lastEventArgs;
    public Throttle(EventHandler<TEventArgs> eventHandler, TimeSpan interval)
    {
        _timer = new DispatcherTimer
        {
            Interval = interval
        };
        _timer.Tick += (s, e) =>
        {
            _timer.Stop();
            eventHandler(_lastSender, _lastEventArgs);
        };
    }
    public void ProcessEvent(object sender, TEventArgs args)
    {
        _timer.Stop();
        _timer.Start();
        _lastSender = sender;
        _lastEventArgs = args;
    }
}
MainPage.xaml.cs
c#
public sealed partial class MainPage : Page
{
    private readonly Throttle<PointerRoutedEventArgs> _throttle;
    public MainPage()
    {
        this.InitializeComponent();
        var interval = TimeSpan.FromMilliseconds(300);
        _throttle = new Throttle<PointerRoutedEventArgs>(HandleEvent, interval);
        MyUIElement.PointerMoved += (sender, e) => _throttle.ProcessEvent(sender, e);
    }
    private void HandleEvent(object sender, PointerRoutedEventArgs e)
    {
        Debug.WriteLine("Pointer Moved");
    }
}
