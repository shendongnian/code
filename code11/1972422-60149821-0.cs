    public HttpResponseMessage PostRequest<T>(T value)
    {
        using (var client = new System.Net.Http.HttpClient())
        {
            client.BaseAddress = new Uri(_BaseAddress);
            var postTask = client.PostAsJsonAsync<T>("student", value);
            var result = postTask.Result; // Task.Result waits for the result: https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1.result?view=netframework-4.8
            return result;
        }
    }
