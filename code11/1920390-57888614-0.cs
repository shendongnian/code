    public class MockReferenceDataService : IReferenceDataService
    {
        public Task<List<ReferenceDataResults>> GetReferenceData(string domain, string concept)
        {
            // Your code
            return Task.FromResult(ret);
        }
    }
