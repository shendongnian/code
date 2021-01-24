    class CefSharpScreenshotRecorder
    {
      private TaskCompletionSource<System.Drawing.Bitmap> TaskCompletionSource { get; set; }
      public Task<System.Drawing.Bitmap> TakeScreenshotAsync(
        ChromiumWebBrowser browserInstance, 
        TaskCreationOptions optionalTaskCreationOptions = TaskCreationOptions.None)
      {
        this.TaskCompletionSource = new TaskCompletionSource<System.Drawing.Bitmap>(optionalTaskCreationOptions);
    
        browserInstance.Paint += GetScreenShotOnPaint;
        // Return Task instance to make this method awaitable
        return this.TaskCompletionSource.Task;
      }
      
      private void GetScreenShotOnPaint(object sender, PaintEventArgs e)
      { 
        (sender as ChromiumWebBrowser).Paint -= GetScreenShotOnPaint;
        System.Drawing.Bitmap newBitmap = new Bitmap(e.Width, e.Height, 4 * e.Width, PixelFormat.Format32bppRgb, e.Buffer);
 
        // Optional: save the screenshot to the hard disk "MyPictures" folder
        var screenshotDestinationPath = Path.Combine(Environment.GetFolderPath(
          Environment.SpecialFolder.MyPictures), "CefSharpBrowserScreenshot.png");
        newBitmap.Save(screenshotDestinationPath);
    
        // Create a copy of the bitmap, since the underlying buffer is reused by the library internals
        var bitmapCopy = new System.Drawing.Bitmap(newBitmap);
        // Set the Task.Status of the Task instance to 'RanToCompletion'
        // and return the result to the caller
        this.TaskCompletionSource.SetResult(newBitmap);
      }
      public BitmapImage ConvertToBitmapImage(System.Drawing.Bitmap bitmap)
      {
        using(var memoryStream = new MemoryStream())
        {
          bitmap.Save(memoryStream, ImageFormat.Png);
          memoryStream.Position = 0;
          BitmapImage bitmapImage = new BitmapImage();
          bitmapImage.BeginInit();
          bitmapImage.StreamSource = memoryStream;
          bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
          bitmapImage.EndInit();
          bitmapImage.Freeze();
        }
      }
    }
