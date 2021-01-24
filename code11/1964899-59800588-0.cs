c#
panel1.AutoScroll = true;
The Paint event:
c#
private void Panel1_Paint(object sender, PaintEventArgs e)
{
    var g = e.Graphics;
    //Your inputs
    var xNum = 30;
    var yNum = 25;
    var cellSize = new Size(20, 20);
    //
    using (Matrix m = new Matrix(1, 0, 0, 1, panel1.AutoScrollPosition.X, panel1.AutoScrollPosition.Y))
    {
        g.Transform = m;
        g.Clear(panel1.BackColor);
        for (var i = 0; i < xNum; i++)
        for (var j = 0; j < yNum; j++)
            g.DrawRectangle(Pens.Blue, 
                i * cellSize.Width, 
                j * cellSize.Height, 
                cellSize.Width, cellSize.Height);
    }
    panel1.AutoScrollMinSize = new Size(cellSize.Width * (xNum + 1), cellSize.Height * (yNum + 1));
}
Also you may want to derive a new class that inherits the `Panel` control to enable the `DoubleBuffered` property which is needed to reduce the flicker while scrolling:
c#
class PanelEx : Panel
{
    public PanelEx()  
    {
        DoubleBuffered = true;
        AutoScroll = true;
    }
}
