    // in view model
    public delegate void MyEventAction(string someparameter, ...);
    public event MyEventAction MyEvent { get; set; }
    // rise event when you need to
    if(MyEvent != null)
        MyEvent("123", ...);
    // in view
    var vm = (MyViewModel)DataContext;
    vm.MyEvent += (a, ...) => ... // do something
