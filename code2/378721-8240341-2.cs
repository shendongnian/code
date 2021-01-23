    using System.Windows.Forms;
    using System.Drawing;
    ...
    
    private void Form1_Load(object sender, EventArgs e)
    {
        var item = new NotifyIcon(this.components);
        item.Visible = true;
        item.Icon = System.Drawing.SystemIcons.Information;
        item.ShowBalloonTip(3000, "Balloon title", "Balloon text", ToolTipIcon.Info);
    }
