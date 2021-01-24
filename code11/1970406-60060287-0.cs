    public IQueryable<Person> FilterPeopleOnPersonCriteria(IQueryable<Person> people, Person p)
    {
    	var t = p.GetType();
    	var fields = t
    		.GetFields()
    		.Where(x => x.FieldType == typeof(string) &&
    		!string.IsNullOrEmpty((string)t.GetField(x.Name).GetValue(p)))
    		.Select(x => x.Name);
    	foreach (var f in fields)
    	{
    		var fi = t.GetField(f);
    		string pVal = (string)fi.GetValue(p);
    		if (pVal.Contains('*'))
    		{
    			var query = $"{f}.{(pVal.StartsWith("*") ? "Ends" : "Starts")}With(@0)";
    			people = people.Where(query, pVal.Replace("*", ""));
    		}
    		else
    		{
    			var query = $"{f} == @0";
    			people = people.Where(query, pVal);
    		}
    	}
    	return people;
    }
