c#
var resultTask = new TaskCompletionSource<PNAccessManagerGrantResult>();
pubnub.Grant()
            .Channels(new string[] {
            "channel"
            })
            .Read(true)
            .Write(true)
            .AuthKeys(new List<string>() { "xyz" }.ToArray())
            .TTL(0)
            .Async(new PNAccessManagerGrantResultExt((result, status) =>
            {
               resultTask.TrySetResult(result);
            }));
var syncResult = resultTask.Task.Result;
