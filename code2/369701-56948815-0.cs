C#
public static IObservable<T> ThrottleOrImmediate<T>(this IObservable<T> source, TimeSpan delay, IScheduler scheduler)
{
	return Observable.Create<T>((obs, token) =>
	{
		// Next item cannot be send before that time
		DateTime nextItemTime = default;
		return Task.FromResult(source.Subscribe(async item =>
		{
			var currentTime = DateTime.Now;
			// If we already reach the next item time
			if (currentTime - nextItemTime >= TimeSpan.Zero)
			{
				// Following item will be send only after the set delay
				nextItemTime = currentTime + delay;
				// send current item with scheduler
				scheduler.Schedule(() => obs.OnNext(item));
			}
			// There is still time before we can send an item
			else
			{
				// we schedule the time for the following item
				nextItemTime = currentTime + delay;
				try
				{
					await Task.Delay(delay, token);
				}
				catch (TaskCanceledException)
				{
					return;
				}
				// If next item schedule was change by another item then we stop here
				if (nextItemTime > currentTime + delay)
					return;
				else
				{
					// Set next possible time for an item and send item with scheduler
					nextItemTime = currentTime + delay;
					scheduler.Schedule(() => obs.OnNext(item));
				}
			}
		}));
	});
}
First item is immediately sent, then following items are throttled. Then if a following item is sent after the delayed time, it's immediately sent too.
