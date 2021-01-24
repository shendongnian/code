    class MyClass
    {
        public async Task<string> GetRank()
        {
            await Task.Delay(100);
            return "X";
        }
        public async static Task Test()
        {
            var items = new List<MyClass>() { new MyClass(), new MyClass() };
            var grouped = items.GroupByAsync(async _ => (await _.GetRank()));
            foreach (var grouping in await grouped)
            {
                Console.WriteLine($"Key: {grouping.Key}, Count: {grouping.Count()}");
            }
        }
    }
