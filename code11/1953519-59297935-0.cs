    object LockObject { get; set; }
    public void Init() {
        LockObject = new object();
    }
    ...YourMethod() {
        lock ( LockObject ) {
            ...YourTask
        }
    }
