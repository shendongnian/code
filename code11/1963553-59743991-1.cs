using System;
using System.Drawing;
using System.Windows.Forms;
namespace Tests
{
    public class Program
    {
        public static Bitmap TakeScreenshot(string filePath = null)
        {
            var bounds = Screen.PrimaryScreen.Bounds;
            var bmp = new Bitmap(bounds.Width, bounds.Height);
            using (var g = Graphics.FromImage(bmp))
            {
                g.CopyFromScreen(0, 0, 0, 0, bounds.Size);
            }
            if (filePath != null) bmp.Save(filePath);
            return bmp;
        }
        public static void Main()
        {
            Console.WriteLine("Taking a screenshot now...");
            TakeScreenshot("screenshot.bmp");
            Console.WriteLine("\nDone! Press any key to exit...");
            Console.ReadKey();
        }
    }
}
----
**Side note:** Many users have more than one monitor these days, so if you want to take a screenshot that captures *all* the screens, you can create a rectangle that encompasses all screens:
    public static Bitmap TakeScreenshot(string filePath = null)
    {
        var rect = new Rectangle();
        // Take a screenshot that includes all screens by
        // creating a rectangle that captures all monitors
        foreach (var screen in Screen.AllScreens)
        {
            var bounds = screen.Bounds;
            var width = bounds.X + bounds.Width;
            var height = bounds.Y + bounds.Height;
            if (width > rect.Width) rect.Width = width;
            if (height > rect.Height) rect.Height = height;
        }
        var bmp = new Bitmap(rect.Width, rect.Height);
        using (var g = Graphics.FromImage(bmp))
        {
            g.CopyFromScreen(0, 0, 0, 0, rect.Size);
        }
        if (filePath != null) bmp.Save(filePath);
        return bmp;
    }
