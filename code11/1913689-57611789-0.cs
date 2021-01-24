    public class DeviceService : IDeviceService, IDisposable
    {
    
    	readonly IObservable<IDeviceView> Source;
    	private readonly Dictionary<Guid, IObservable<DeviceUpdateEvent>> _updateStreams = new Dictionary<Guid, IObservable<DeviceUpdateEvent>>();
    	private readonly CompositeDisposable _disposable = new CompositeDisposable();
    
    	public DeviceService(IObservable<IDeviceView> source)
    	{ 
    		Source = source;
    
    		var groupedObservable = source
    			.GroupBy(v => v.DeviceId)
    			.Select(o => (o.Key, o
    				.Scan(new DeviceUpdateEvent { View = DeviceTotalView.GetInitialView(o.Key), LastUpdate = null }, (lastTotalView, newView) => lastTotalView.Update(newView))
    				.Replay(1)
    				.RefCount()
    			));
    
    		var groupSubscription = groupedObservable.Subscribe(t =>
    		{
    			_updateStreams[t.Key] = t.Item2;
    			_disposable.Add(t.Item2.Subscribe());
    		});
    		_disposable.Add(groupSubscription);
    	}
    
    	public void Dispose()
    	{
    		_disposable.Dispose();
    	}
    
    	public IObservable<DeviceUpdateEvent> GetDeviceStream(Guid deviceId)
    	{
    		/// How do we implement this? The observable that we return must be pre-loaded with the latest update
    		return this._updateStreams[deviceId];
    	}
    }
