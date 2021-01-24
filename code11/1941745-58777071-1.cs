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
      if ( pos != PreviousMousePosition && !UserMovedMouse)
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
