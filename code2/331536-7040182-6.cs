    private readonly Timer _timerA;
    private readonly Timer _timerB;
    // this is used to protect fields that you will access from your ActionA and ActionB    
    private readonly Object _sharedStateGuard = new Object();
    private readonly List<int> _totRand = new List<int>();
    public void Controller() {
        _timerA = new Timer(ActionA, null, TimeSpan.Zero, TimeSpan.FromSeconds(30));
        _timerB = new Timer(ActionB, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
    }
    private void ActionA(object param) {
        // IMPORTANT: wrap every call that uses shared state in this lock
        lock(_sharedStateGuard) {
            // do something with 'totRand' list here           
        }
    }
    private void ActionB(object param) {
        // IMPORTANT: wrap every call that uses shared state in this lock
        lock(_sharedStateGuard) {
            // do something with 'totRand' list here           
        }
    }
    
