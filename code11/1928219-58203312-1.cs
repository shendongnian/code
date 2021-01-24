    public void Test()
    	{
    		List<double> tags = new List<double>() {5, 7, 9, 13, 10.1, 25.6, 32.1};
    		
    		List<Tuple<double, double>> results = GetElementsWhosSumIsGreaterThanX(tags, 20);
    		
    		for (int i = 0; i < results.Count; i++)
		{
			Console.WriteLine("{0} and {1} have a sum greater than 20", results[i].Item1, results[i].Item2);
		}
		
		/*output:
		5 and 25.6 have a sum greater than 20
		5 and 32.1 have a sum greater than 20
		7 and 25.6 have a sum greater than 20
		9 and 13 have a sum greater than 20
		13 and 13 have a sum greater than 20
		*/
    	}
