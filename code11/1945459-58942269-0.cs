c#
public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        AutoScroll = true;
    }
}
and the painting routine:
c#
private void Form1_Paint(object sender, PaintEventArgs e)
{
    using (Matrix m = new Matrix(1, 0, 0, 1, AutoScrollPosition.X, AutoScrollPosition.Y))
    {
        var sY = VerticalScroll.Value;
        var sH = ClientRectangle.Y;
        var w = ClientRectangle.Width - 2 - (VerticalScroll.Visible ? SystemInformation.VerticalScrollBarWidth : 0);
        var h = ClientRectangle.Height;                
        var paintRect = new Rectangle(0, sY, w, h); //This will be your painting rectangle.
        var g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.Transform = m;
        g.Clear(BackColor);
        using (Pen pn = new Pen(Color.Black, 2))
            e.Graphics.DrawLine(pn, 100, 50, 100, 1000);
        sH += 1050; //Your line.y + line.height
        //Likewise, you can increase the w to show the HorizontalScroll if you need that.
        AutoScrollMinSize = new Size(w, sH);
    }
}
Good Luck.
