public async Task<string> RenderPage(string baseUrl, string url, string cookieName, string cookieValue)
    {
      await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);
      using (var browser = await Puppeteer.LaunchAsync(new LaunchOptions { Headless = false }))      
      {
        using (var page = await browser.NewPageAsync())
        {
          await page.GoToAsync(baseUrl);
          await page.SetCookieAsync(new CookieParam { 
            Name = cookieName, 
            Value = cookieValue, 
          });
          await page.GoToAsync(baseUrl + url);
          await page.WaitForSelectorAsync("table.summary-table");
          var cookies = await page.GetCookiesAsync(baseUrl + url);
          var element = await page.QuerySelectorAsync("html");
          var text = await (await element.GetPropertyAsync("innerHTML")).JsonValueAsync<string>();
          Console.WriteLine(text);
          return text;
        }
      }
    }
Not sure why my code above did not work, though...
