    public abstract class KeeperBase<T>
    {
        List<T> Items;
    	
    	public Keeper() { }
    
    	protected abstract string GetRefreshApi { get; }
    	public async Task Refresh()
    	{
            if (Items.Any())
            {
                Items.Clear();
            }
    
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(new Uri(GetRefreshApi)))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var userJsonString = await response.Content.ReadAsStringAsync();
                        //how to put the passed type to DeserializeObject<>?
                        Items = JsonConvert.DeserializeObject<T[]>(userJsonString).ToList();
                    }
                }
            }
    	}
    }
    public class CarKeeper : KeeperBase<Car>
    {
    	protected override string GetRefreshApi => Secrets.ApiAddress + "GetCars?token=" + Secrets.TenantToken + "&page=1";
    }
    public class EmployeeKeeper : KeeperBase<Employee>
    {
    	protected override string GetRefreshApi => Secrets.ApiAddress + "GetEmployees?token=" + Secrets.TenantToken + "&page=1";
    }
