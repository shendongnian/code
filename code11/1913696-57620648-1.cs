csharp
class DeviceService : IDeviceService, IDisposable {
    readonly CompositeDisposable _disposable = new CompositeDisposable();
    readonly ConcurrentDictionary<Guid, Lazy<BehaviorSubject<DeviceUpdateEvent>>> _streams = new ConcurrentDictionary<Guid, Lazy<BehaviorSubject<DeviceUpdateEvent>>>();
    BehaviorSubject<DeviceUpdateEvent> GetCreateSubject(Guid deviceId) {
        return _streams.GetOrAdd(deviceId, Create).Value;
        Lazy<BehaviorSubject<DeviceUpdateEvent>> Create(Guid id) {
            return new Lazy<BehaviorSubject<DeviceUpdateEvent>>(() => {
                var subject = new BehaviorSubject<DeviceUpdateEvent>(DeviceUpdateEvent.GetInitialView(deviceId));
                _disposable.Add(subject);
                return subject;
            });
        }
    }
    public DeviceService(IConnectableObservable<IDeviceView> source) {
        _disposable.Add(source
            .GroupBy(x => x.DeviceId)
            .Subscribe(deviceStream => {
                _disposable.Add(deviceStream
                    .Scan(DeviceUpdateEvent.GetInitialView(deviceStream.Key), DeviceUtils.Update)
                    .Subscribe(GetCreateSubject(deviceStream.Key)));
            }));
        _disposable.Add(source.Connect());
    }
    public void Dispose() {
        _disposable.Dispose();
    }
    public IObservable<DeviceUpdateEvent> GetDeviceStream(Guid deviceId) {
        return GetCreateSubject(deviceId).AsObservable();
    }
}
csharp
[TestMethod]
public async Task Test2() {
    var input = new AsyncProducerConsumerQueue<IDeviceView>();
    var source = new ConnectableObservableForAsyncProducerConsumerQueue<IDeviceView>(input);
    var service = new DeviceService(source);
    var ids = Enumerable.Range(0, 100000).Select(i => Guid.NewGuid()).ToArray();
    var idsRemaining = ids.ToHashSet();
    var t1 = Task.Run(async () => {
        foreach (var id in ids) {
            await input.EnqueueAsync(new DeviceVoltagesUpdateView { DeviceId = id, Voltage = 1 });
        }
    });
    var t2 = Task.Run(() => {
        foreach (var id in ids) {
            service.GetDeviceStream(id).Subscribe(x => idsRemaining.Remove(x.View.DeviceId));
        }
    });
    await Task.WhenAll(t1, t2);
    var sw = Stopwatch.StartNew();
    while (idsRemaining.Count > 0) {
        if (sw.Elapsed.TotalSeconds > 600) throw new Exception("Failed");
        await Task.Delay(100);
    }
}
See entire problem source code and test code here: https://github.com/bboyle1234/ReactiveTest
