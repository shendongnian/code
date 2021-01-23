	void Main()
	{
		
		List<Address>	lst = new List<Address>();
		lst.Add(new Address{ city = "ny", state = "cy", country = "india"});
		lst.Add(new Address{ city = "ny", state = "cy", country = "india"});
		lst.Add(new Address{ city = "by", state = "cy", country = "india"});
		lst.Add(new Address{ city = "ny", state = "fr", country = "india"});
	        var qry = from addr in lst
			group addr by new { addr.city, addr.state, addr.country } into grp
			select new
			{
				city = grp.Key.city,
				state = grp.Key.state,
				country = grp.Key.country,
				count = grp.Count(),
			};
	        qry.Dump();
	}
	public class Address { public string city; public string state; public string country; }
