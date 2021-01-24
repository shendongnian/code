    class Household
    {
    	public List<string> Cars { get; set; }
    }
    
    var cars = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Dictionary<string, string[]>>>(json);
    List<Household> households = (
    	from h in cars
    	select new Household()
    	{
    		Cars = h["car"].ToList()
    	}
    ).ToList();
