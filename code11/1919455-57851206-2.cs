    public abstract class MyBaseController<T>
    {
        public virtual async Task<IActionResult> GetDetails(int id)
        {
            var result = await _apiService.GetRequest<T>(id);
            // Rest of the processing...
            // If the processing is not generic you may be able to use a delegate to handle that bit.
        }
    }
