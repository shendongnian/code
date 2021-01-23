    using System;
    using System.Windows.Forms;
    using System.Windows.Forms.Integration;
    var wpfwindow = new WPFWindow.Window1();
    ElementHost.EnableModelessKeyboardInterop(wpfwindow);
    wpfwindow.Show();
