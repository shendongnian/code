    using System;
    using System.Windows.Forms;
    public class WebBrowserEx : WebBrowser
    {
       public WebBrowserEx()
       {
       }
       protected override void WndProc(ref Message m)
       {
          switch (m.Msg)
          {
             case 0x021:
             case 0x201:
             case 0x204:
             case 0x207:
                 base.DefWndProc(ref m);
                 return;
          }
          base.WndProc(ref m);
       }
    }
