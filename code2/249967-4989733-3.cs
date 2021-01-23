    class <>somehorriblename {
        public object someObj;
        public void SomeGeneratedName() { Function(someObj); }
    }
    ...
    var captureClass = new <>somehorriblename();
    captureClass.someObj = ...
    Action action = captureClass.SomeGeneratedName;
