    var sessionState = new Dictionary<string, object>();
    MHttpContext.CurrentGet = // ...
    {
        // ...
        ItemGetString = (key) =>
        {
            object result = null;
            sessionState.TryGetValue(key, out result);
            return result;
        }
