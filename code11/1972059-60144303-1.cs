c#
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace Pixel_detection_test_3
{
    public partial class PixelDetectionForm : Form
    {
        private readonly Timer Tmr;
        private Point lastPoint;
        //Assign this from your input code.
        private Color targetColor;
        public PixelDetectionForm()
        {
            Tmr = new Timer { Interval = 50 };
            Tmr.Tick += (s, e) => FindMatches(Cursor.Position);
        }
        //...
In the timer's `Tick` event, the `FindMatches(..)` method is called to check the current `Cursor.Position` and add the distinct matches into a `ListBox`. You can replace the last part with what you really need to do when you find a match. Like calling the `MousePress()` method in your code:
c#
        //...
        private void FindMatches(Point p)
        {
            //To avoid the redundant calls..
            if (p.Equals(lastPoint)) return;
            lastPoint = p;
            using (var b = new Bitmap(1, 1))
            using (var g = Graphics.FromImage(b))
            {
                g.CopyFromScreen(p, Point.Empty, b.Size);
                var c = b.GetPixel(0, 0);
                if (c.ToArgb().Equals(targetColor.ToArgb()) &&
                    !listBox1.Items.Cast<Point>().Contains(p))
                {
                    listBox1.Items.Add(p);
                    listBox1.SelectedItem = p;
                }
            }
        }
        private void PixelDetectionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Tmr.Dispose();
        }
    }
}
Start and stop the timer in the click events of the `Start` and `Stop` buttons.
Here's a demo:
[![SOQ60128615][1]][1]
Another alternative is to use the Global Mouse and Keyboard Hooks. Check [this](https://stackoverflow.com/questions/604410/global-keyboard-capture-in-c-sharp-application), [this](https://stackoverflow.com/questions/44990335/is-there-any-way-to-global-hook-the-mouse-actions-like-im-hooking-the-keyboard), and [this](https://www.codeproject.com/Articles/7294/Processing-Global-Mouse-and-Keyboard-Hooks-in-C) for more details.
---
**Edit 2/11/2020**
If you just want to check whether a given color at a given point exists in a given image, then you can do:
c#
private void buttonStart_Click_Click(object sender, EventArgs e)
{
    var targetColor = ...; //target color.
    var targetPoint = ...; //target point.
    var sz = Screen.PrimaryScreen.Bounds.Size;
    using (var b = new Bitmap(sz.Width, sz.Height, PixelFormat.Format32bppArgb))
    using (var g = Graphics.FromImage(b))
    {
        g.CopyFromScreen(Point.Empty, Point.Empty, b.Size, CopyPixelOperation.SourceCopy);
        var bmpData = b.LockBits(new Rectangle(Point.Empty, sz), ImageLockMode.ReadOnly, b.PixelFormat);
        var pixBuff = new byte[bmpData.Stride * bmpData.Height];
        Marshal.Copy(bmpData.Scan0, pixBuff, 0, pixBuff.Length);
        b.UnlockBits(bmpData);
        for (var y = 0; y < b.Height; y++)
        for(var x = 0; x < b.Width; x++)
        {
            var pos = (y * bmpData.Stride) + (x * 4);
            var blue = pixBuff[pos];
            var green = pixBuff[pos + 1];
            var red = pixBuff[pos + 2];
            var alpha = pixBuff[pos + 3];
            if (Color.FromArgb(alpha, red, green, blue).ToArgb().Equals(targetColor.ToArgb()) &&
                new Point(x, y).Equals(targetPoint))
            {
                //execute you code here..
                MessageBox.Show("The given color exists at the given point.");
                return;
            }
        }
    }
    MessageBox.Show("The given color doen not exist at the given point.");
}
If you want to get a list of all the positions of a given color, then create a new `List<Point>()` and change the check condition to:
c#
//...
var points = new List<Point>();
if (Color.FromArgb(alpha, red, green, blue).ToArgb().Equals(targetColor.ToArgb()))
{
    points.Add(new Point(x, y));
}
  [1]: https://i.stack.imgur.com/GREak.gif
