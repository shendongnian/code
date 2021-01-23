    using System.Threading;
    using WpfThreading = System.Windows.Threading;
    ...
    Thread t = new Thread(() => 
    {
        var interval = TimeSpan.FromSeconds(3.0);
        var priority = WpfThreading.DispatcherPriority.Background;
        EventHandler callback = (a, e) => { };
        var dispatcher = WpfThreading.Dispatcher.CurrentDispatcher; // dispatcher for this thread
        WpfThreading.DispatcherTimer dt = new WpfThreading.DispatcherTimer(interval, priority, callback, dispatcher);
    
        bool sameDispatchers = WpfThreading.Dispatcher.CurrentDispatcher == this.Dispatcher; // false
    });
    t.Start();
