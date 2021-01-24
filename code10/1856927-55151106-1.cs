    public static List<CondensedData> GetAddresses(List<AddressData> data)
    {
    	return data.Select(m=>new CondensedData(){Address=m.FullAddress}).ToList();
    }
    public class CondensedData
    {
    	public string Address {get;set;}
    }
