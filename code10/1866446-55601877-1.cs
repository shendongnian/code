C#
using ...
using APIcsharp;
class ScanMgr
{
  int ID = 0;
  public string startUp(IntPtr hwmd, uint wmApp)
  {
    int state;
    ID = NativeAPI.StartUp(hwmd, wmApp);
    if(ID != 0)
    {
      do { NativeAPI.GetState(ID, out state); }
      while(state == (int)(DevStates.StartingUp)); // DevStates is a enum
      return "Device on";
    }
    return "Error turning on";
  }
  /* Other stuff to do */
}
 3. Then, defined an override method for the messages
C#
public partial class Form1 : Form
{
  const uint wm_channel = 0x8000 + 1;
  ScanMgr scanner = new ScanMgr();
  public Form1()
  { InitializeComponent(); }
  private void StartBtn_Click(object sender, EventArgs e)
  { log.Items.Add(scanner.startUp(this.Handle, wm_channel)); }
  /* Other stuff yadda yadda */
  protected override void WndProc(ref Message m)
  {
    base.WndProc(ref m);
    if(m.Msg == wm_channel)
    { /* To do stuff with m.WParam and m.LParam */ }
  }
}
