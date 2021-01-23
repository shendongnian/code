    using System.Windows.Forms;
    using System.Drawing;
    ...
    var icon = new NotifyIcon();
    icon.ShowBalloonTip(3000, "Balloon title", "Balloon text", ToolTipIcon.None)
