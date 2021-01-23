    public class GenericDisposable : IDisposable
            {
                Action _act = null;
                IDisposable _disp = null;
                public GenericDisposable(Action act,IDisposable disp)
                {
                    _act = act;
                    _disp = disp;
                }
                public void Dispose()
                {
                    _act();
                    _disp.Dispose();
                }
            }
            public static IObservable<DependencyPropertyChangedEventHandler> CreateForEvent()
            {
                return Observable.Defer(() =>
                {
                    return Observable.CreateWithDisposable<DependencyPropertyChangedEventHandler>(obs =>
                    {
                        var subject = new Subject<DependencyPropertyChangedEventHandler>();
                        //Attach event handler and on event call OnNext of subject with the value
                        return new GenericDisposable(() => {/*remove event handler*/}, subject.Subscribe(obs));
                    });
                });
            }
