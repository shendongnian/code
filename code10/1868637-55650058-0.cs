	List<string> symbolList = new List<string>() { "AAPL", "QQQ", "FB", "MSFT", "IBM" };
	Task[] taskArray = new Task[symbolList.Count];
	for (int i = 0; i < taskArray.Length; i++)
	{
		string symbol = symbolList[i];
		taskArray[i] = Task.Factory.StartNew(() =>
		{
			criteriaEvalution.Evaluate(finalArray, false, new List<parseObj>(), ref builder, symbol);
		});
	}
	Task.WaitAll(taskArray);
