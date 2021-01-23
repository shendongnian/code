    private Timer _timerA;
    private Timer _timerB;
    
    public void Controller() {
        _timerA = new Timer(ActionA, null, TimeSpan.Zero, new TimeSpan(0, 0, 0, 30));
        _timerB = new Timer(ActionB, null, TimeSpan.Zero, new TimeSpan(0, 0, 0, 1));
    }
    public void ActionA(object state) {
        // IMPORTANT: wrap every call that uses shared state in lock(){}
    }
    private void ActionB(object state) {
        // IMPORTANT: wrap every call that uses shared state in lock(){}        
    }
    
