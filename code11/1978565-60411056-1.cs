    var klines = _client.GetKlines(bot.Symbol, bot.Interval, limit: 51 + 20).Data.SkipLast(1).ToList(); // 50 elements + previous 20 for the first element
    var ranges = ToRanges(klines, 20);
    var smaData = ranges.Select(r => new {
        OpenTime = r.First().OpenTime.ToLocalTime(),
        SMA5 = ExponentialMovingAverage.SMA(r.TakeLast(5)), 
        SMA10 = ExponentialMovingAverage.SMA(r.TakeLast(10)),
        SMA20 = ExponentialMovingAverage.SMA(r)
    });
    
    foreach(var item in smaData)
    {
       Console.WriteLine($"OpenTime: {item.OpenTime.ToLocalTime()} | MA5: {decimal.Round(item.SMA5, 6, MidpointRounding.AwayFromZero)} | MA10: {decimal.Round(item.SMA10, 6, MidpointRounding.AwayFromZero)} | MA20: {decimal.Round(item.SMA20, 6, MidpointRounding.AwayFromZero)}");
    }
    
    private IEnumerable<IEnumerable<int>> ToRanges(IEnumerable<int> list, int rangeSize)
    {
    	var queue = new Queue<int>(splitSize);
    	foreach(var item in list)
    	{
    		queue.Enqueue(item);
    		if(queue.Count == rangeSize)
    		{
    			yield return queue;
    			queue.Dequeue();
    		}
    	}
    }
