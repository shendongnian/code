public MainPageViewModel()
{
   var EmployeeList =  GetEmployees();
   Employees = new ObservableCollection<Employee>(EmployeeList.Result);
}
        
private async Task<List<Employee>> GetEmployees()
{
   using (var httpClient = CreateClient())
   {
     var response = await httpClient.GetAsync(ApiBaseAddress).ConfigureAwait(false);
     var test = response;
     if (response.IsSuccessStatusCode)
     {
       var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
       if (!string.IsNullOrWhiteSpace(json))
       {
          var EmployeeList = JsonConvert.DeserializeObject<List<Employee>>(json);
          return EmployeeList;
       }                    
     }
     return null;
    }
}
