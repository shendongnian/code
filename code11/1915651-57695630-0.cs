    class CefSharpScreenshotRecorder
    {
      private TaskCompletionSource<Bitmap> TaskCompletionSource { get; set; }
      public Task<Bitmap> TakeScreenshotAsync(ChromiumWebBrowser browserInstance)
      {
        this.TaskCompletionSource = new TaskCompletionSource<Bitmap>();
    
        browserInstance.Paint += GetScreenShotOnPaint;
        // Return Task instance to make this method awaitable
        return this.TaskCompletionSource.Task;
      }
      
      private void GetScreenShotOnPaint(object sender, PaintEventArgs e)
      { 
        (sender as ChromiumWebBrowser).Paint -= GetScreenShotOnPaint;
        Bitmap newBitmap = new Bitmap(e.Width, e.Height, 4 * e.Width, PixelFormat.Format32bppRgb, e.Buffer);
        var aPath = Path.Combine(Environment.GetFolderPath(
          Environment.SpecialFolder.MyPictures), "TestImageCefSharpQuant.png");
        newBitmap.Save(aPath);
    
        // Set the Task instance to 'RunToCompletion' and return the result
        this.TaskCompletionSource.SetResult(newBitmap);
      }
    }
