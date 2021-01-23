    // define in the view model
    public delegate void MyEventAction(string someParameter, ...);
    public event MyEventAction MyEvent;
    // rise event when you need to
    MyEvent?.Invoke("123", ...);
    // in the view
    var vm = (MyViewModel)DataContext;
    vm.MyEvent += (someParameter, ...) => ... // do something
