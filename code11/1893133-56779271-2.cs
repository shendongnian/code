c#
using System;
using System.Threading;
using System.Threading.Tasks;
using CefSharp;
using CefSharp.WinForms;
public static class ChromiumWebBrowserExtensions
{
    public static async Task ShowDevToolsAsync(
        this ChromiumWebBrowser browser,
        CancellationToken cancellationToken)
    {
        browser.ShowDevTools();
        while (true)
        {
            cancellationToken.ThrowIfCancellationRequested();
            // Detect if console is open
            var result = await browser.EvaluateScriptAsync(@"
(function(){
    // Inspired by https://stackoverflow.com/a/7809413/3063273
    var detector = function(){};
    detector.isOpened = false;
    detector.toString = function(){
        this.isOpened = true;
    };
    console.log('%c', detector);
    return detector.isOpened;
})()
", timeout: TimeSpan.FromSeconds(1));
            if (!result.Success)
            {
                throw new Exception(result.Message);
            }
            if (!(result.Result is bool isOpened))
                continue;
            if (isOpened)
                break;
            await Task.Delay(TimeSpan.FromMilliseconds(100), cancellationToken);
        }
    }
}
Example usage (using an additional extension method I don't show above, but you should get the gist):
c#
public async Task DemonstrateAsync(ChromiumWebBrowser browser, CancellationToken cancellationToken)
{
    // Give DevTools something to hook into
    await browser.LoadDataUrlAsync("<html>Waiting for DevTools to load...</html>", cancellationToken);
    // Show DevTools and wait until it's up
    await browser.ShowDevToolsAsync(cancellationToken);
    // Give the Javascript debugger a breakpoint
    await browser.LoadDataUrlAsync("<html><script>debugger;</script></html>", cancellationToken);
}
Edit: added async delay to reduce the iteration count of the `while` loop. 100ms is an arbitrary number that for me reduced the iteration count from >300 to ~3.
  [1]: https://i.stack.imgur.com/OaPGV.png
