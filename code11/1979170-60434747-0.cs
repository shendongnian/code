	public Dictionary<string, Employee> getEmployees() {
		return new Dictionary<string, Employee>();
	}
    public Dictionary<string, Customer> getCustomers() {
		return new Dictionary<string, Customer>();
	}
	public List<Dictionary<string, object>> getDifferentItems()
	{
   		List<Dictionary<string, object>> listOfItems = new List<Dictionary<string, object>>();
   		listOfItems.Add(this.getEmployees().ToDictionary(entry => (string)entry.Key,
                  entry => (object)entry.Value)); 
   		listOfItems.Add(this.getCustomers().ToDictionary(entry => (string)entry.Key,
                  entry => (object)entry.Value)); 
   		return listOfItems;
	}
### Create one dictionary with all the values
	public Dictionary<string, Employee> getEmployees() {
		return new Dictionary<string, Employee>();
	}
    public Dictionary<string, Customer> getCustomers() {
		return new Dictionary<string, Customer>();
	}
	public Dictionary<string, object> getDifferentItems()
	{
   		Dictionary<string, object> listOfItems = new Dictionary<string, object>();
		foreach (var entry in getEmployees()) {
			listOfItems.Add(entry.Key, entry.Value);
		}
		foreach (var entry in getCustomers()) {
			listOfItems.Add(entry.Key, entry.Value);
		}
   		return listOfItems;
	}
