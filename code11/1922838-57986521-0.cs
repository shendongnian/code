cs
static void Main(string[] args) {
	//Only allow 3 requests in a time window of 10 seconds.
	var r = new RollingTimeWindow(3, TimeSpan.FromSeconds(10), () => Console.WriteLine("Executed."));
	while (true) {
		Console.ReadLine(); //wait for press on Enter
		r.PerformRequest();
	}
}
This is a simple code to get you started to handle your rolling time window:
cs
public class RollingTimeWindow {
	private Queue<DateTime> _latestRequests = new Queue<DateTime>();
	private readonly int _maxNumberOfRequests;
	private readonly TimeSpan _windowSize;
	private Action _action;
	/// <summary>
	/// Creates a new RollingTimeWindow performing requests if allowed by the time frame.
	/// </summary>
	/// <param name="maximumNumberOfRequests">Number of requests allowed in the window size</param>
	/// <param name="windowSize">Rolling window size</param>
	/// <param name="requestAction">Action to invoke when the request must be performed</param>
	public RollingTimeWindow(int maximumNumberOfRequests, TimeSpan windowSize, Action requestAction = default) {
		_action = requestAction;
		_maxNumberOfRequests = maximumNumberOfRequests;
		if (_maxNumberOfRequests < 0) {
			throw new ArgumentException(nameof(maximumNumberOfRequests));
		}
		_windowSize = windowSize;
	}
    //Returns true if the request would be allowed, else false (NOT threadsafe)
	public bool IsRequestAllowed() {
		CleanQueue(DateTime.Now);
		return _latestRequests.Count < _maxNumberOfRequests;
	}
	//Returns true if the request was performed, else false.
	public bool PerformRequest() {
		var now = DateTime.Now;
		CleanQueue(now);
		if (_latestRequests.Count < _maxNumberOfRequests) {
			_latestRequests.Enqueue(now);
			_action(); //perform the actual request
			return true;
		} else {
			return false; //request not allowed
		}
	}
	private void CleanQueue(DateTime now) {
		//Cleans all requests older than the window size
		while (_latestRequests.Count > 0 && _latestRequests.Peek() < now - _windowSize) {
			_latestRequests.Dequeue();
		}
	}
}
Note that this is not thread-safe, and that it could also be implemented with ```Timer``` objects to automatically dequeue older values.
