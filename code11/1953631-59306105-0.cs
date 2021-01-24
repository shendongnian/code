       Dictionary<string, int> Status = new Dictionary<string, int>() {
       {"Status1", 0},
       {"Status2", 1},
       {"Status3", 1},
       {"Status4", 2},
       {"Status5", 2},
       {"Status6", 3}};
		
		var Units = new string[] { "Unit1", "Unit2", "Unit3", "Unit4" };
		
		MoneyMovement[4] movements = new MoneyMovement[4];
		for(int i=0;i<4;i++)
			movements[i] = new MoneyMovement() { CollectionUnit = Units[i] };
		
		foreach(var item in paymentsCollection)
		{
			var m = movements[Status[item.PaymentStatus]];
			m.MoneyCollected += item.Amount;
			m.NoOfReceipt++;
		}
		
