    var list = new List<int> {14,2,13,11,5,8,21,12,3};
    var tested = 11;
    
    var closestGreater = list.OrderBy(n => n)
    			             .FirstOrDefault(n => tested < n); // = 12
    
    var closestLess = list.OrderByDescending(n => n)
    					  .FirstOrDefault(n => tested > n); // = 8
    
    if (closestGreater == 0)
    	System.Diagnostics.Debug.WriteLine(
    		string.Format("No number greater then {0} exists in the list", tested));
    
    if (closestLess == 0)
    	System.Diagnostics.Debug.WriteLine(
    		string.Format("No number smaler then {0} exists in the list", tested));
