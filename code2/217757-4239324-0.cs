    class MainWindow : ...
    {
        public MyClass1 MyObject1 { get; private set; }
        public MyClass1 MyObject2 { get; private set; }
        ...
        var slaveWindow = new SlaveWindow(this);
        ...
    }
    class SlaveWindow : ...
    {
        public SlaveWindow(MainWindow mainWindow)
        {
            mainWindow.MyObject1.SomeMethod();
            mainWindow.MyObject2.SomeMethod();
        }
    }
