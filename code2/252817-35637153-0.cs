    using System.Collections.Async;
    static IAsyncEnumerable<string> ProduceItems(string[] urls)
    {
      return new AsyncEnumerable<string>(async yield => {
        foreach (var url in urls) {
          var html = await UrlString.DownLoadHtmlAsync(url);
          await yield.ReturnAsync(html);
        }
      });
    }
    static async Task ConsumeItemsAsync(string[] urls)
    {
      await ProduceItems(urls).ForEachAsync(async html => {
        await Console.Out.WriteLineAsync(html);
      });
    }
