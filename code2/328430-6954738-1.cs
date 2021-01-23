    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    class Program
    {
        static void Main()
        {
            NotifyIcon icon = new NotifyIcon();
            icon.Icon = new Icon("C:\\Windows\\System32\\PerfCenterCpl.ico");
            icon.Visible = true;
            icon.Click += (s,e) => new Form().Show();
            icon.DoubleClick += (s,e) => Application.Exit();
            Application.Run();
        }
    }
