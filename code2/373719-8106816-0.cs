    private delegate void beforeGroup( MyObject current, MyObject changesTo );
    private delegate void afterGroup( MyObject current, MyObject changedFrom );
    public MyObject P1 {
        get {
            return p1;
        }
        set {
            beforeGroup( p1, value );
            MyObject oldValue = p1;
            p1 = value;
            afterGroup( p1, oldValue );
        }
    }
