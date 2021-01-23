	using System;
	using System.Collections.Concurrent;
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Linq;
	using System.Threading;
	using System.Threading.Tasks;
    /// <summary>
    /// High resolution scheduler. 
    /// License: public domain (no restrictions or obligations)
    /// Author: Vitaly Vinogradov
    /// </summary>
	public class HiResScheduler : IDisposable
	{
		/// <summary>
		/// Scheduler would automatically downgrade itself to cold loop (Sleep(1)) when there are no
		/// tasks earlier than the treshold. 
		/// </summary>
		public const int HOT_LOOP_TRESHOLD_MS = 16;
		protected class Subscriber : IComparable<Subscriber>, IComparable
		{
			public Action Callback { get; set; }
			public double DelayMs { get; set; }
			public Subscriber(double delay, Action callback)
			{
				DelayMs = delay;
				Callback = callback;
			}
			public int CompareTo(Subscriber other)
			{
				return DelayMs.CompareTo(other.DelayMs);
			}
			public int CompareTo(object obj)
			{
				if (ReferenceEquals(obj, null))
					return -1;
				var other = obj as Subscriber;
				if (ReferenceEquals(other, null))
					return -1;
				return CompareTo(other);
			}
		}
		private Thread _spinner;
		private ManualResetEvent _allowed = new ManualResetEvent(false);
		private AutoResetEvent _wakeFromColdLoop = new AutoResetEvent(false);
		private bool _disposing = false;
		private bool _adding = false;
		private List<Subscriber> _subscribers = new List<Subscriber>();
		private List<Subscriber> _pendingSubscribers = new List<Subscriber>();
		public bool IsActive { get { return _allowed.WaitOne(0); } }
		public HiResScheduler()
		{
			_spinner = new Thread(DoSpin);
			_spinner.Start();
		}
		public void Start()
		{
			_allowed.Set();
		}
		public void Pause()
		{
			_allowed.Reset();
		}
		public void Enqueue(double delayMs, Action callback)
		{
			lock (_pendingSubscribers)
			{
				_pendingSubscribers.Add(new Subscriber(delayMs, callback));
				_adding = true;
				if (delayMs <= HOT_LOOP_TRESHOLD_MS * 2)
					_wakeFromColdLoop.Set();
			}
		}
		private void DoSpin(object obj)
		{
			var sw = new Stopwatch();
			sw.Start();
			var nextFire = null as Subscriber;
			while (!_disposing)
			{
				_allowed.WaitOne();
				if (nextFire != null && sw.Elapsed.TotalMilliseconds >= nextFire?.DelayMs)
				{
					var diff = sw.Elapsed.TotalMilliseconds;
					sw.Restart();
					foreach (var item in _subscribers)
						item.DelayMs -= diff;
					foreach (var item in _subscribers.Where(p => p.DelayMs <= 0).ToList())
					{
						item.Callback?.Invoke();
						_subscribers.Remove(item);
					}
					nextFire = _subscribers.FirstOrDefault();
				}
				if (_adding)
					lock (_pendingSubscribers)
					{
						_subscribers.AddRange(_pendingSubscribers);
						_pendingSubscribers.Clear();
						_subscribers.Sort();
						_adding = false;
						nextFire = _subscribers.FirstOrDefault();
					}
				if (nextFire == null || nextFire.DelayMs > HOT_LOOP_TRESHOLD_MS)
					_wakeFromColdLoop.WaitOne(1);
				else
					_wakeFromColdLoop.WaitOne(0);
			}
		}
		public void Dispose()
		{
			_disposing = true;
		}
	}
