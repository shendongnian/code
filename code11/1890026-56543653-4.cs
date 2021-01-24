    void Main()
    {
    	var ps = new List<(string col, string opr, string value)>();
    	ps.Add(("0", "gt", "6"));
    	ps.Add(("1", "like", "30.0"));
    	ps.Add(("2", "ne", "60"));
    	
    	var loopData = new List<ShoeModels> {
		    new ShoeModels { Range = new[] { 5.0m, 10.0m, 15.0m }}, // leaves out on first filter ps[0]
		    new ShoeModels { Range = new[] { 10.0m, 20.0m, 30.0m }},// leaves out on second filter ps[1]
		    new ShoeModels { Range = new[] { 10.0m, 30.0m, 30.0m }},// this is the final result of all three filters
		    new ShoeModels { Range = new[] { 15.0m, 30.0m, 60.0m }},// leaves out on third filter ps[2]
	    };
    	
    	loopData.Dump("initial data");
    	
    	List<ShoeModels> res = loopData;
    	
    	var query = new Query();
    	for (int i = 0; i < ps.Count; i++)
    	{
    		decimal number;
    		if (Decimal.TryParse(ps[i].value, out number))
            {
                query.numValue = number;
            }
            else
            {
                query.filterValue = ps[i].value;
            }
            query.filterColumn = ps[i].col;
            query.opr = ps[i].opr.ToLower();
            IEnumerable<ShoeModels> tuyo = null;
    
    		if (query.opr == "gt" || query.opr == "lt" || query.opr == "gte" || query.opr == "lte" || query.opr == "ne")
            {
                tuyo = res.Where(a => comparer(a, query.filterColumn, query.opr, query.numValue));
            }
            else if (query.opr.ToLower() == "like")
            {
                tuyo = res.Where(a => (a[query.filterColumn]).ToString(CultureInfo.InvariantCulture).Contains(query.filterValue));
            }
    		res = tuyo.ToList();
    		res.Dump("after " + i + " iteration");
    	}
    	res.Dump("final result");
    }
    
    private Func<ShoeModels, string, string, decimal, bool> comparer = (ShoeModels a, string column, string op, decimal value) =>
    {
        switch (op)
        {
            case "lt": return a[column] < value;
            case "gt": return a[column] > value;
            case "gte": return a[column] >= value;
            case "lte": return a[column] <= value;
            case "ne": return a[column] != value;
            default:
                break;
        }
        return true;
    };
    
    class Query {
    	public decimal numValue { get; set;}
    	public string filterValue { get; set;}
    	public string filterColumn {get; set;}
    	public string opr {get; set;}
    }
    			
    class ShoeModels {	
    	public decimal[] Range = new decimal[3];
    	public decimal this[string index] {
    		get => Range[int.Parse(index)];
    	}
    	
    	public override string ToString() => 
    		$"{Range[0].ToString(CultureInfo.InvariantCulture)} " +
    		$"{Range[1].ToString(CultureInfo.InvariantCulture)} " +
    		$"{Range[2].ToString(CultureInfo.InvariantCulture)}";
    }
