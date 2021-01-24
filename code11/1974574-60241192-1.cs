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
---------------------------------
**Update**
> I'm struggling to work out how everything fits together in an MVVM environment. The logic that needs to be triggered by the event is contained within the ViewModel but the View and ViewModel should be entirely separate.
There's a couple things I'd like to mention:
- You're right about the need for separation of concerns, but a lot of devs are unclear of what that exactly entails. The view model should be completely unaware of who's listening, there's no doubt about that. But the view is dependent on the view model to get its data, so it's okay for the view to know about the view model. The problem is more about doing so in a loosely coupled way, ie. using bindings and contracts instead of directly accessing view model members.
- That's why I'm not particularly fond of Caliburn's Actions. With `cal:Message.Attach` there's no contract (eg. ICommand) to decouple view syntax from the view model's. Of course, there are bindings in play, so you still get decoupled MVVM layers.
Long story short, there's a reason people choose ReactiveUI over Rx.NET for WPF development.
From the view's code behind (_.xaml.cs) it gives you access to:
- The backing `ViewModel` 
- A binding system to keep it all loosely coupled
And, of course, `ReactiveCommands`, which would also come in handy in your use case.
Final thoughts, if your view has the same lifetime as your view model (ie. they get disposed together), you could be pragmatic about it and get the view model through the `DataContext` of your view.
