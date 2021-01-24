`
using System;
using System.Windows.Forms;
using System.Threading;
namespace WindowsFormsAppTest
{
  public partial class FormTest : Form
  {
    static volatile protected object locker = new object();
    static protected bool CancelRequired = false;
    protected Thread Thread;
`
`
    public FormTest()
    {
      InitializeComponent();
      Thread = new Thread(ThreadFunc);
      Thread.Start();
    }
`
`
    private void ButtonAction_Click(object sender, EventArgs e)
    {
      lock ( locker ) CancelRequired = true;
      while ( Thread.IsAlive ) Application.DoEvents();
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
