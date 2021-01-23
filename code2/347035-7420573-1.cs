    var svc = new ServiceContainer();
    var a1 = new A(svc);
    var a2 = new A(svc);
    a1.ChangeService();
    a1.Call(); // call the created service
    a2.Call(); // the service created in a1 will be called
    a2.ChangeService();
    a1.Call(); // the service created in a2 will be called
