    Subject<string> messenger = new Subject<string>();
    messenger.Where(o => o.Length > 0).Subscribe(file => { Console.WriteLine("got file request: " + file); });
    
    var pathObservable = Observable.Return<string>("File 1");
    pathObservable.Subscribe(v => messenger.OnNext(v));
    
    var pathObservable2 = Observable.Return<string>("File 2");
    pathObservable2.Subscribe(v => messenger.OnNext(v));
    
    messenger.OnNext("File 3");
    
    Console.ReadLine();
