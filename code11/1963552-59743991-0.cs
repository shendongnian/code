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
