    public class EmployeeController
    {
        public async Task<IActionResult> GetDetails(int id)
        {
            var result = await _apiService.GetRequest<Employee>(id);
            // Rest of the processing...
        }
    }
