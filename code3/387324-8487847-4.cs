    using System.Web.Fakes;
    // ...
    var sessionState = new Dictionary<string, object>();
    ShimHttpContext.CurrentGet = () => new ShimHttpContext();
    ShimHttpContext.AllInstances.SessionGet = (o) => new ShimHttpSessionState
    {
        ItemGetString = (key) =>
        {
            object result = null;
            sessionState.TryGetValue(key, out result);
            return result;
        }
    };
