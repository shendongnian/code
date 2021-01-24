cs
// SignalR Hub 
public class CrawlHub : Hub
{
    // A wrapper iterator so can catch exceptions here which can't be done in 
    // a block which does yield return
    public async IAsyncEnumerable<UIMessage> Crawl(string url, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var enumerable = CrawlAndGetMessages(url, cancellationToken);
        await using var enumerator = enumerable.GetAsyncEnumerator(cancellationToken);
        for (var more = true; more;)
        {
            // Catch exceptions only on executing/resuming the iterator function
            try
            {
                more = await enumerator.MoveNextAsync();
            }
            catch (Exception ex)
            {
                Log.Fatal("IteratorFunction() threw exception: " + ex);
                throw;
            }
            // yield out this UIMessage this has to be outside a try catch block
            yield return enumerator.Current;
        }
    }
    public async IAsyncEnumerable<UIMessage> CrawlAndGetMessages(string url, [EnumeratorCancellation]CancellationToken cancellationToken)
    {
        // handing off to Crawler which returns back messages (UIMessage objects) every now and again on progress
        await foreach (var uiMessage in Crawler.Crawl(url, cancellationToken))
        {
            // Check the cancellation token regularly so that the server will stop
            // producing items if the client disconnects.
            cancellationToken.ThrowIfCancellationRequested();
            if (uiMessage.Message.Contains("404"))
                // it should be displayed on the error list - this is not a stream
                await Clients.Caller.SendAsync("ReceiveBrokenLinkMessage", "404 error on blah", cancellationToken);
            else
                // update the stream UI with whatever is happening in static Crawl
                yield return new UIMessage(uiMessage.Message, uiMessage.Hyperlink, uiMessage.NewLine);
        }
    }
}
Thanks to @JeroenMostert and @TheodorZoulias in the comments above and the [Jackson Dunstan article](https://jacksondunstan.com/articles/3038).  I'll post improvements when I understand more about this.
