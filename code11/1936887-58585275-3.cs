enum Shapes
{
    Ellipse,
    Rectangle,
    Line
}
int x, y, w, h;
Shapes shape;
+ Validate the user's input in the _ExecuteBtn_ click event, assign the values, and call the _OutputBox.Invalidate()_ if the input is correct.
var cmd = textBox1.Text.Split(' ');
var validCmds = Enum.GetNames(typeof(Shapes));
if (cmd.Length < 5 || !validCmds.Contains(cmd[0], StringComparer.OrdinalIgnoreCase))
{
    MessageBox.Show("Enter a valid command.");
    return;
}
if(!int.TryParse(cmd[1], out x) || 
    !int.TryParse(cmd[2], out y) ||
    !int.TryParse(cmd[3], out w) ||
    !int.TryParse(cmd[4], out h))                    
{
    MessageBox.Show("Enter a valid shape");
    return;
}
shape = (Shapes)validCmds.ToList().FindIndex(a => a.Equals(cmd[0], StringComparison.OrdinalIgnoreCase));
OutputBox.Invalidate();
+ Draw the shape in the _Paint_ event.
private void OutputBox_Paint(object sender, PaintEventArgs e)
{
    if (w > 0 && h > 0)
    {
        e.Graphics.Clear(Color.White);
        e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        using (Pen pn = new Pen(Color.Black, 5))
        {
            switch (shape)
            {
                case Shapes.Ellipse:
                    e.Graphics.DrawEllipse(pn, x, y, w, h);
                    break;
                case Shapes.Rectangle:
                    e.Graphics.DrawRectangle(pn, x, y, w, h);
                    break;
                case Shapes.Line:
                    e.Graphics.DrawLine(pn, x, y, w, h);
                    break;
            }
        }
    }
}
---
**Better yet, [TerribleDog's](https://stackoverflow.com/users/10344668/terribledog) approach as he commented.**
+ Create the _Shape_ class to enumerate your shapes, declare properties for them, and a method to parse a given command string and outs the required shape on success:
c#
public class Shape
{
    #region enums.
    public enum Shapes
    {
        Ellipse,
        Rectangle,
        Line
    }
    #endregion
    #region Constructors
    public Shape()
    { }
    public Shape(Shapes shape, int x, int y, int width, int height)
    {
        ThisShape = shape;
        X = x;
        Y = y;
        Width = width;
        Height = height;
    }
    #endregion
    #region Properties
    public Shapes ThisShape { get; set; } = Shapes.Ellipse;
    public int X { get; set; }
    public int Y { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    #endregion
    #region Methods
    public static bool TryParse(string input, out Shape result)
    {
        result = null;
        if (string.IsNullOrEmpty(input))
            return false;
        var cmd = input.Split(' ');
        var validCmds = Enum.GetNames(typeof(Shapes));
        if (cmd.Length < 5 || !validCmds.Contains(cmd[0], StringComparer.OrdinalIgnoreCase))
            return false;
        int x, y, w, h;
        if (!int.TryParse(cmd[1], out x) ||
            !int.TryParse(cmd[2], out y) ||
            !int.TryParse(cmd[3], out w) ||
            !int.TryParse(cmd[4], out h))
            return false;
        var shape = (Shapes)validCmds.ToList().FindIndex(a => a.Equals(cmd[0], StringComparison.OrdinalIgnoreCase));
        result = new Shape(shape, x, y, w, h);
        return true;
    }
    #endregion
}
+ The _ExecuteBtn_ click event:
c#
//shape is a class level variable.
shape = null;
//The _ExecuteBtn_ click event
if (!Shape.TryParse(textBox1.Text, out shape))
{
    MessageBox.Show("Enter a valid command.");
    return;
}
OutputBox.Invalidate();
//
+ Finally, your paint event:
c#
private void OutputBox_Paint(object sender, PaintEventArgs e)
{
    if (shape != null)
    {
        e.Graphics.Clear(Color.White);
        e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        using (Pen pn = new Pen(Color.Black, 5))
        {
            switch (shape.ThisShape)
            {
                case Shape.Shapes.Ellipse:
                    e.Graphics.DrawEllipse(pn, shape.X, shape.Y, shape.Width, shape.Height);
                    break;
                case Shape.Shapes.Rectangle:
                    e.Graphics.DrawRectangle(pn, shape.X, shape.Y, shape.Width, shape.Height);
                    break;
                case Shape.Shapes.Line:
                    //Note: the Width and Height properties play here the X2 and Y2 roles.
                    e.Graphics.DrawLine(pn, shape.X, shape.Y, shape.Width, shape.Height);
                    break;
            }
        }
    }
}
Good luck.
