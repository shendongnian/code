    public static Task<Bitmap> TakeScreenshotAsync(this ChromiumWebBrowser source)
    {
        var tcs = new TaskCompletionSource<Bitmap>(
            TaskCreationOptions.RunContinuationsAsynchronously);
        source.Paint += ChromiumWebBrowser_Paint;
        return tcs.Task;
        void ChromiumWebBrowser_Paint(object sender, PaintEventArgs e)
        {
            source.Paint -= ChromiumWebBrowser_Paint;
            using (var temp = new Bitmap(e.Width, e.Height, 4 * e.Width,
                PixelFormat.Format32bppPArgb, e.Buffer))
            {
                tcs.SetResult(new Bitmap(temp));
            }
        }
    }
