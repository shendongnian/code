    private bool attemptOne(IEnumerable coll)
    {
    	var s = coll.GetType().GetGenericArguments()[0];
    	return s.IsValueType;
    }
	var lstTwo = new List<int>();
	lstTwo.Add(1);
	lstTwo.Add(3);
	Console.WriteLine(attemptOne(lstTwo)); // Returns true
