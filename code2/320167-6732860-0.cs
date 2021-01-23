    using System.Windows.Forms;
    
    namespace Test
    {
      public class WndProcOverride : Form
      {
        protected override void WndProc(ref Message m)
        {
          base.WndProc(ref m);
        }
      }
    }
