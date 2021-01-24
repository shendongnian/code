    public static Task<Bitmap> TakeScreenshotAsync(this ChromiumWebBrowser source)
    {
        var tsc = new TaskCompletionSource<Bitmap>(
            TaskCreationOptions.RunContinuationsAsynchronously);
        source.Paint += ChromiumWebBrowser_Paint;
        return tsc.Task;
        void ChromiumWebBrowser_Paint(object sender, PaintEventArgs e)
        {
            source.Paint -= ChromiumWebBrowser_Paint;
            var bitmap = new Bitmap(e.Width, e.Height, 4 * e.Width,
                PixelFormat.Format32bppRgb, e.Buffer);
            tsc.SetResult(bitmap);
        }
    }
