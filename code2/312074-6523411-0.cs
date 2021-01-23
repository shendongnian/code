    Dictionary<string, Tuple<int,decimal>> dico = new Dictionary<string, Tuple<int,decimal>>();
    foreach (var itemEstimation in test)
    {
    	Estimation estimation = (Estimation)itemEstimation;
    	if (dico.ContainsKey(estimation.Code) == false)
    	{
    		decimal total = 0;
    		foreach (var item in estimation.EstimationItems)
    		{
    			EstimationItem estimationItem = (EstimationItem)item;
    			total += item.Price * item.Quantity;
    		}
    		dico.Add(estimation.Code, new Tuple<int, decimal>(estimation.EstimationItems.Sum(x => x.Quantity), total));
    	}
    }
    
    List<TestingUI> finalResult = new List<TestingUI>();
    foreach (var item in dico)
    {
    	Tuple<int, decimal> result;
    	dico.TryGetValue(item.Key, out result);
    	finalResult.Add(new TestingUI() { Code = item.Key, Quantity = result.Item1, Total = result.Item2 }); 
    }
