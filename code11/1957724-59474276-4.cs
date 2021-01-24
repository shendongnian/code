    public static async Task<HtmlElement> WaitForElementAsync(this WebBrowser wb,
        string elementId, int timeout = 30000, int interval = 500)
    {
        var stopwatch = Stopwatch.StartNew();
        while (true)
        {
            try
            {
                var element = wb.Document.GetElementById(elementId);
                if (element != null) return element;
            }
            catch { }
            if (stopwatch.ElapsedMilliseconds > timeout) throw new TimeoutException();
            await Task.Delay(interval);
        }
    }
