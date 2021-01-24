C#
using ...
using APIcsharp;
class ScanMgr
{
  int ID = 0;
  [DllImport(@"C:\Windows\System32\user32.dll", EntryPoint = "GetMessage", CharSet = CharSet.Ansi)]
  public static extern bool GetMessage([In, Out] ref MSG msg, IntPtr hWnd, int uMsgFilterMin, int uMsgFilterMax);
public string startUp(IntPtr hwmd)
{
  int state;
  ID = NativeAPI.StartUp(hwmd, 10); // <--- This 10 is important
  if(ID != 0)
  {
    do { NativeAPI.GetState(ID, out state); }
    while(state == (int)(DevStates.StartingUp));
    return "Device on";
  }
  return "Error turning on";
}
/* Other stuff to do */
 3. Then, defined an override method for the messages
C#
public partial class Form1 : Form
{
  ScanMgr scanner = new ScanMgr();
  public Form1()
  { InitializeComponents }
  private void StartBtn_Click(object sender, EventArgs e)
  { log.Items.Add(scanner.startUp(this.Handle); }
  /* Other stuff yadda yadda */
  protected override void WndProc(ref Message m)
  {
    base.WndProc(ref m);
    if(m.Msg == 10) // The number I used in StartUp method
    { /* To do stuff with m.WParam and m.LParam */ }
  }
}
