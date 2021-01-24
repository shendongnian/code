`
using System;
using System.Windows.Forms;
using System.Threading;
namespace WindowsFormsAppTest
{
  public partial class FormTest : Form
  {
    static volatile protected bool CancelRequired = false;
    protected Thread TheThread;
`
`
    public FormTest()
    {
      InitializeComponent();
      TheThread = new Thread(ThreadFunc);
      TheThread.Start();
    }
`
`
    private void ButtonAction_Click(object sender, EventArgs e)
    {
      CancelRequired = true;
      while ( TheThread.IsAlive ) 
        Application.DoEvents();
      Application.Exit();
    }
`
`
    private void ThreadFunc()
    {
      while ( !CancelRequired )
      {
        // Do stuff
        Thread.Sleep(40);
      }
    }
`
`
  }
}
