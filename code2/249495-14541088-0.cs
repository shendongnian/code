    var oTask = Observable.FromAsync(() => Task.Factory.StartNew(() =>
                                                                 {
                                  Thread.Sleep(1000);
                                  Console.WriteLine("Executed Task");
                                                                 }));
    //Setup the IConnectedObservable
    var oTask2 = oTask.PublishLast();
    //Subscribe - nothing happens
    oTask2.Subscribe(x => { Console.WriteLine("Called from Task 1"); });
    oTask2.Subscribe(x => { Console.WriteLine("Called from Task 2"); });
    //The one and only time the Task is run
    oTask2.Connect();
    //Subscribe after the task is already complete - we want the results
    Thread.Sleep(5000);
    oTask2.Subscribe(x => { Console.WriteLine("Called from Task 3"); });
