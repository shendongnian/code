    public class Service
    {
        public async Task<string> MethodOne()
        {
            // do something
            var result = await CalculateSomeResult();
            return result;
        }
        public async Task MethodTwo(Task<string> task)
        {
            // do some work
            // do some work
            var methodOneResult = await task;
            // do something with the result of methodOne
        }
    }
