xml
<Page ...>
    <Grid Background="White">
    </Grid>
</Page>
csharp
private GestureRecognizer _GestureRecognizer;
PointerEventHandler PointerPressedEventHandler;
PointerEventHandler PointerMovedEventHandler;
PointerEventHandler PointerReleasedEventHandler;
PointerEventHandler PointerCanceledEventHandler;
private double startY = 0;
private double moveY = 0;
public GesturePage()
{
    this.InitializeComponent();
    _GestureRecognizer = new GestureRecognizer();
    _GestureRecognizer.GestureSettings = GestureSettings.ManipulationTranslateY;
    _GestureRecognizer.ManipulationStarted += _GestureRecognizer_ManipulationStarted;
    _GestureRecognizer.ManipulationUpdated += _GestureRecognizer_ManipulationUpdated;
    _GestureRecognizer.ManipulationCompleted += _GestureRecognizer_ManipulationCompleted;
    PointerPressedEventHandler = new PointerEventHandler(_PointerPressed);
    PointerMovedEventHandler = new PointerEventHandler(_PointerMoved);
    PointerReleasedEventHandler = new PointerEventHandler(_PointerReleased);
    PointerCanceledEventHandler = new PointerEventHandler(_PointerCanceled);
    this.AddHandler(UIElement.PointerPressedEvent, PointerPressedEventHandler, true);
    this.AddHandler(UIElement.PointerMovedEvent, PointerMovedEventHandler, true);
    this.AddHandler(UIElement.PointerReleasedEvent, PointerReleasedEventHandler, true);
    this.AddHandler(UIElement.PointerCanceledEvent, PointerCanceledEventHandler, true);
}
private void _GestureRecognizer_ManipulationStarted(GestureRecognizer sender, ManipulationStartedEventArgs args)
{
    startY = args.Position.Y;
}
private void _GestureRecognizer_ManipulationUpdated(GestureRecognizer sender, ManipulationUpdatedEventArgs args)
{
    moveY += Math.Abs(args.Delta.Translation.Y);
}
private void _GestureRecognizer_ManipulationCompleted(GestureRecognizer sender, ManipulationCompletedEventArgs args)
{
    if (moveY >= 50)
    {
        // Can be understood as sliding a distance
        if (startY <= 10)
        {
            // head to foot
        }
        else if (startY >= Window.Current.Bounds.Height - 10)
        {
            // foot to head
        }
        startY = 0;
        MoveY = 0;
    }
}
private void _PointerPressed(object sender, PointerRoutedEventArgs e)
{
    var pointer = e.GetCurrentPoint(this);
    _GestureRecognizer.ProcessDownEvent(pointer);
}
private void _PointerMoved(object sender, PointerRoutedEventArgs e)
{
    var pointers = e.GetIntermediatePoints(this);
   _GestureRecognizer.ProcessMoveEvents(pointers);
}
private void _PointerCanceled(object sender, PointerRoutedEventArgs e)
{
    var pointer = e.GetCurrentPoint(this);
    _GestureRecognizer.CompleteGesture();
}
private void _PointerReleased(object sender, PointerRoutedEventArgs e)
{
    var pointer = e.GetCurrentPoint(this);
    _GestureRecognizer.ProcessUpEvent(pointer);
}
Fingers, mouse, and pens trigger `Pointer` related events when they tap the screen. The purpose of the above code is to capture the `Pointer` event and pass it to `GestureRecognizer` for processing.
Here is the [document](https://docs.microsoft.com/en-us/uwp/api/windows.ui.input.gesturerecognizer)
Best regards.
