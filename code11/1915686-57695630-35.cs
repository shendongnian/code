    class CefSharpScreenshotRecorder
    {
      private TaskCompletionSource<System.Drawing.Bitmap> TaskCompletionSource { get; set; }
      public async Task<System.Drawing.Bitmap> TakeScreenshotAsync(ChromiumWebBrowser browser, string url)
      {
        if (!string.IsNullOrEmpty(url))
        {
          throw new ArgumentException("Invalid URL", nameof(url));
        }
        this.TaskCompletionSource = new TaskCompletionSource<Bitmap>();
        // Load the page. In the loaded event handler 
        // take the snapshot and return it asynchronously it to caller
        return await LoadPageAsync(browser, url);
      }
      private Task<System.Drawing.Bitmap> LoadPageAsync(IWebBrowser browser, string url)
      {
        browser.LoadingStateChanged += GetScreenShotOnLoadingStateChanged;
        browser.Load(url);
        // Return Task instance to make this method awaitable
        return this.TaskCompletionSource.Task;
      }
      
      private async void GetScreenShotOnLoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
      { 
        browser.LoadingStateChanged -= GetScreenShotOnLoadingStateChanged;
        System.Drawing.Bitmap screenshot = await browser.ScreenshotAsync(true);
        // Set the Task.Status of the Task instance to 'RanToCompletion'
        // and return the result to the caller
        this.TaskCompletionSource.SetResult(screenshot);
      }
    }
