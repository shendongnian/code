    public Task<List<S3Object>> ListObjectsAsync(string bucket_name, string identityId) {
        TaskCompletionSource<List<S3Object>> tcs = new TaskCompletionSource<List<S3Object>>();
        var request = new ListObjectsV2Request() {
            BucketName = bucket_name,
            Prefix = identityId
        };
        Client.ListObjectsV2Async(request, (responseObject) => {
            if (responseObject.Exception == null) {
                tcs.TrySetResult(responseObject.Response.S3Objects.ToList());
            } else {
                Debug.Log(responseObject.Exception);
                tcs.TrySetException(responseObject.Exception);
            }
        });
        // return the object after the callback is finished
        return tcs.Task;
    }
