    class MyObject
    {
        public MyObject(FileInfo file) { /* etc... */ }
        public MyObject(string content) { /* etc... */ }
    }
    ...
    MyObject o = new MyObject(new FileInfo(filename));
