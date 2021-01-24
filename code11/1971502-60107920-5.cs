    private async IAsyncEnumerable<Item> GetItemAfterDelay(IEnumerable<Item> items)
    {
        DateTime previousItemTimestamp = items.First().Timestamp;
        foreach(var i in items)
        {
            var delay = i.Timestamp - previousItemTimestamp;
            await Task.Delay(delay);
            yield return i;
            previousItemTimestamp = i.Timestamp;
        }
    }
