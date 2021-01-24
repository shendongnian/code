    public class RecordController
    {
        public async Task<IActionResult> GetDetails(int id)
        {
            var result = await _apiService.GetRequest<Record>(id);
            // Rest of the processing...
        }
    }
