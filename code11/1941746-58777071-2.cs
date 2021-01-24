public partial class FormTest : Form
{
  Point PreviousMousePosition;
  bool UserMovedMouse;
  public FormTest()
  {
    InitializeComponent();
    PreviousMousePosition = Cursor.Position;
    TimerCheckMouseMove.Start();
    TimerMoveMouse.Start();
    HookManager.MouseMove += HookManager_MouseMove;
  }
  private void HookManager_MouseMove(object sender, MouseEventArgs e)
  {
    PreviousMousePosition = Cursor.Position;
    UserMovedMouse = true;
  }
  private void TimerCheckMouseMove_Tick(object sender, EventArgs e)
  {
    timer1.Enabled = false;
    try
    {
      var pos = Cursor.Position;
      if ( !UserMovedMouse && pos != PreviousMousePosition)
        MessageBox.Show("Mouse moved by a process");
      PreviousMousePosition = Cursor.Position;
      UserMovedMouse = false;
    }
    finally
    {
      timer1.Enabled = true;
    }
  }
  private void TimerMoveMouse_Tick(object sender, EventArgs e)
  {
    Cursor.Position = new Point(100, 100);
  }
}
**Using a threaded timer**
    System.Threading.Timer TimerCheckMouseMove;
    TimerCheckMouseMove = new System.Threading.Timer(TimerCheckMouseMove_Tick, null, 0, 100);
    private bool TimerCheckMouseMoveMutex;
    private void TimerCheckMouseMove_Tick(object state)
    {
      if ( TimerCheckMouseMoveMutex ) return;
      TimerCheckMouseMoveMutex = true;
      try
      {
        var pos = Cursor.Position;
        if ( !UserMovedMouse && pos != PreviousMousePosition)
          MessageBox.Show("Mouse moved by a process");
        PreviousMousePosition = Cursor.Position;
        UserMovedMouse = false;
      }
      finally
      {
        TimerCheckMouseMoveMutex = false;
      }
    }
