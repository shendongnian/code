c#
const float speedXPerSecond = 1000f / 30;
const int bar_width = 40;
public Form1()
{
    InitializeComponent();
    DoubleBuffered = true;
}
float x_position = 0;
TimeSpan _lastFrameTime = TimeSpan.Zero;
Stopwatch _frameTimer = Stopwatch.StartNew();
protected override void OnPaint(PaintEventArgs e)
{
    base.OnPaint(e);
    TimeSpan currentFrameTime = _frameTimer.Elapsed;
    float distance = (float)(currentFrameTime - _lastFrameTime).TotalSeconds * speedXPerSecond;
    x_position += distance;
    while (x_position > this.Width) x_position -= this.Width;
    e.Graphics.FillRectangle(Brushes.Black, x_position, 0, bar_width, 500);
    _lastFrameTime = currentFrameTime;
    Invalidate();
}
You can apply this general technique to any interactive scenario. A real game will have other elements to this general "render loop", including user input and updating game state (e.g. based on a physics model). These will add overhead to the render loop, and will necessarily reduce frame rate. But for any basic game on any reasonably recent hardware (e.g. built in the last couple of decades), the net frame rate will still be well above that needed for acceptably smooth game-play.
Do note that in the managed .NET/Winforms context, there will always be limits to the success of this approach as compared to using a lower-level API. In particular, without some extra work on your part, garbage collection will interrupt periodically, causing the frame rate to stutter slightly, as well unevenness in thread scheduling and the thread's message queue.
But it's been my experience that people asking this sort of question don't need things to be absolutely perfect. They need "good enough", so that they can move on to learning about other topics involved in game development.
