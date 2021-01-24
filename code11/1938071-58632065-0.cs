    public static IEnumerable<decimal> MovingAverages(IEnumerable<decimal> values, int sample)
    {
    	var queue = new Queue<decimal>(sample);
    	decimal sum = 0;
    	foreach(var x in values)
    	{
    		sum += x;
    		queue.Enqueue(x);
    		if(queue.Count == sample)
    		{
    			yield return sum / sample;
    			sum -= queue.Dequeue();
    		}
    	}
    }
