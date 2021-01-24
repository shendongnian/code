    static class Program
    {
        [STAThread]
        static void Main()
        {
            BufferedGraphicsContext currentContext;
            BufferedGraphics backBuffer;
            currentContext = BufferedGraphicsManager.Current;
            Graphics screenGraphics = Graphics.FromHwnd(IntPtr.Zero);
            backBuffer = currentContext.Allocate(screenGraphics, Screen.PrimaryScreen.Bounds);
            int i = 0;
            while (true)
            {
                //Things are static, but you can render an animation here.
                backBuffer.Graphics.Clear(Color.Red);
                backBuffer.Graphics.FillRectangle(Brushes.White, 50, 50, 100, 100);
                backBuffer.Render();
                //it'll stop after 1000 frames rendered
                i++;
                if (i > 1000)
                    break;
            }
        }
    }
