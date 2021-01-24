    var collection = new BlockingCollection<object>();
    var subscription = SubscribeToStreamAsync().Result;
    try {
        var enumerable = collection.GetConsumingEnumerable();
        foreach (var item in enumerable) {
            yield return item;
        }
    } finally {
        // foreach or stream is completed
        Unsubscribe( subscription ).Wait();
    }
