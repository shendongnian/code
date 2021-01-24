c#
public Form1()
{
    InitializeComponent();
    pozíció = Position.Left;
    timer2.Start();
}
+ The `Timer.Tick` event:
c#
private void timer2_Tick(object sender, EventArgs e)
{
    //Hint: You might want to keep the rectangle within the canvas.
    pozíció = x < 0 ? Position.Right : x + 21 > pictureBox1.ClientRectangle.Right ? Position.Left : pozíció;
    pozíció = y < 0 ? Position.Down : y + 21 > pictureBox1.ClientRectangle.Bottom ? Position.Up : pozíció;
    switch (pozíció)
    {
        case Position.Right:
            x += 3;
            break;
        case Position.Left:
            x -= 3;
            break;
        case Position.Up:
            y -= 3;
            break;
        case Position.Down:
            y += 3;
            break;
        default:
            x = 0;
            y = 0;
            break;
    }
    pictureBox4.Invalidate();
}
+ You can write the `enum` block as follows:
c#
enum Position
{
    Left = 37,
    Up,
    Right,
    Down,
}
Where `37` is the `KeyCode` of the `Left` key, and consequently `Up` = `38`, `Right` = `39`, and `Down` = `40`. So you can _shrink_ the `KeyDown` event as follows:
c#
private void Form1_KeyDown(object sender, KeyEventArgs e)
{
    if (e.KeyCode == Keys.Left ||
        e.KeyCode == Keys.Up ||
        e.KeyCode == Keys.Right ||
        e.KeyCode == Keys.Down)
    {
        pozíció = (Position)e.KeyCode;
        pictureBox4.Invalidate();
    }
}
+ To show/hide the image, handle the `CheckedChanged` instead:
c#
private void checkBox1_CheckedChanged(object sender, EventArgs e)
{
    pictureBox4.Image = checkBox1.Checked ? Táblázat2 : null;
}
Presuming that the `Táblázat2` is a class level variable = `Image.FromFile(@"D:\Táblázat2.JPG");` assigned in the Form's constructor.
+ The `Paint` event:
c#
private void pictureBox4_Paint(object sender, PaintEventArgs e)
{
    e.Graphics.FillRectangle(Brushes.Blue, x, y, 20, 20);
}
+ Alternatively, and as you are handling the `Paint` event, you can get rid of the `CheckedChanged` event of the `CheckBox` control and draw the image yourself:
c#
private void pictureBox4_Paint(object sender, PaintEventArgs e)
{
    var g = e.Graphics;
    if (checkBox1.Checked)
    {
        var sz = Táblázat2.Size;
        var r = e.ClipRectangle;
        g.SmoothingMode = SmoothingMode.HighQuality;
        g.DrawImage(Táblázat2,
        new Rectangle((r.Width - sz.Width) / 2, (r.Height - sz.Height) /2, sz.Width, sz.Height),
        new Rectangle(0, 0, sz.Width, sz.Height),
        GraphicsUnit.Pixel);
    }
    g.FillRectangle(Brushes.Blue, x, y, 20, 20);
}
and just in case the timer is not enabled:
c#
private void checkBox1_CheckedChanged(object sender, EventArgs e)
{
    pictureBox4.Invalidate();
}
Good luck.
