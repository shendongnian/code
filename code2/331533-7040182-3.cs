    private Timer _timerA;
    private Timer _timerB;
    // this is used to protect fields that you will access from your ActionA and ActionB    
    private readonly Object _sharedStateGuard = new Object();
    public void Controller() {
        _timerA = new Timer(ActionA, null, TimeSpan.Zero, TimeSpan.FromSeconds(30));
        _timerB = new Timer(ActionB, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
    }
    public void ActionA(object state) {
        // IMPORTANT: wrap every call that uses shared state in this lock
        // lock(_sharedStateGuard) {            
        // }
    }
    private void ActionB(object state) {
        // IMPORTANT: wrap every call that uses shared state in this lock
        // lock(_sharedStateGuard) {            
        // }
    }
    
