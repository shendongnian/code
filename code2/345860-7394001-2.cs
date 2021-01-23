    // Responds to a new message by starting a new job on the thread pool.
    private void RespondToNewMessage(IPacketMsg message)
    {
        IJob job = ..;
        Task.Factory.StartNew(job.RunJob(message));
    }
    // Holds tasks waiting for a response.
    private ConcurrentDictionary<int, TaskCompletionSource<IResponse>> responseTasks = ..;
    // Asynchronously gets a response for the specified reply.
    public Task<IResponse> GetResponseForReplyAsync(int replyId)
    {
        var tcs = new TaskCompletionSource<IResponse>();
        responseTasks.Add(replyId, tcs);
        return tcs.Task;
    }
    // Responds to a new response by completing and removing its task.
    private void RespondToResponse(IResponse response)
    {
        var tcs = responseTasks[response.ReplyId];
        responseTasks.Remove(response.ReplyId);
        tcs.TrySetComplete(response);
    }
