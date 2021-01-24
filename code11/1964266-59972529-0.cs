    public class MyMock : ISomeInterface
    {
        public Task<DateTime> GetDateAsync() // no async
        {
            // Directly return a completed task return a fake result
            return Task.FromResult(new DateTime(2019, 11, 12, 0, 0, 0, DateTimeKind.Utc));
        }
    }
