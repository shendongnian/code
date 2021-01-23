    /// <summary>
    /// Take screenshot of a Window.
    /// </summary>
    /// <remarks>
    /// - Usage example: screenshot icon in every window header.                
    /// - Keep well away from any Windows Forms based methods that involve screen pixels. You will run into scaling issues at different
    ///   monitor DPI values. Quote: "Keep in mind though that WPF units aren't pixels, they're device-independent @ 96DPI
    ///   "pixelish-units"; so really what you want, is the scale factor between 96DPI and the current screen DPI (so like 1.5 for
    ///   144DPI) - Paul Betts."
    /// </remarks>
    public async Task<bool> TryScreenshotToClipboardAsync(FrameworkElement frameworkElement)
    {
        frameworkElement.ClipToBounds = true; // Can remove if everything still works when the screen is maximised.
        Rect relativeBounds = VisualTreeHelper.GetDescendantBounds(frameworkElement);
        double areaWidth = frameworkElement.RenderSize.Width; // Cannot use relativeBounds.Width as this may be incorrect if a window is maximised.
        double areaHeight = frameworkElement.RenderSize.Height; // Cannot use relativeBounds.Height for same reason.
        double XLeft = relativeBounds.X;
        double XRight = XLeft + areaWidth;
        double YTop = relativeBounds.Y;
        double YBottom = YTop + areaHeight;
        var bitmap = new RenderTargetBitmap((int)Math.Round(XRight, MidpointRounding.AwayFromZero),
                                            (int)Math.Round(YBottom, MidpointRounding.AwayFromZero),
                                            96, 96, PixelFormats.Default);
        // Render framework element to a bitmap. This works better than any screen-pixel-scraping methods which will pick up unwanted
        // artifacts such as the taskbar or another window covering the current window.
        var dv = new DrawingVisual();
        using (DrawingContext ctx = dv.RenderOpen())
        {
            var vb = new VisualBrush(frameworkElement);
            ctx.DrawRectangle(vb, null, new Rect(new Point(XLeft, YTop), new Point(XRight, YBottom)));
        }
        bitmap.Render(dv);
        return await TryCopyBitmapToClipboard(bitmap);         
    }        
    private static async Task<bool> TryCopyBitmapToClipboard(BitmapSource bmpCopied)
    {
        var tries = 3;
        while (tries-- > 0)
        {
            try
            {
                // This must be executed on the calling dispatcher.
                Clipboard.SetImage(bmpCopied);
                return true;
            }
            catch (COMException)
            {
                // Race condition on library, we'll try again.
                await Task.Delay(TimeSpan.FromMilliseconds(100));
            }
        }
        return false;
    }	
