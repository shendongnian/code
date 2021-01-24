    public class SomeProcessor
    {
        public async Task ProcessAsync(string payload)
        {
            // some code
            await Task.Delay(1000); // some async action
            // some more code
        }
        public async void ProcessAsyncVoid(string payload)
        {
            // some code
            await Task.Delay(1000); // some async action
            // some more code
        }
    }
