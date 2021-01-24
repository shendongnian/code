    class CefSharpScreenshotRecorder
    {
      private TaskCompletionSource<System.Drawing.Bitmap> TaskCompletionSource { get; set; }
      public async Task<System.Drawing.Bitmap> TakeScreenshotAsync(ChromiumWebBrowser browser, string url)
      {
        this.TaskCompletionSource = new TaskCompletionSource<Bitmap>();
        // Load the page. In the loaded event handler 
        // take the snapshot and return it asynchronously it to caller
        return await LoadPageAsync(browser, url);
      }
      public static Task LoadPageAsync(IWebBrowser browser, string address = null)
      {
        browser.LoadingStateChanged += handler;
        if (!string.IsNullOrEmpty(address))
        {
          browser.Load(address);
        }
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
