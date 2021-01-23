    class MyWatcher : Component {
        private FileSystemWatcher watcher = new FileSystemWatcher();
        public MyWatcher() {
            watcher.EnableRaisingEvents = true;
            watcher.Changed += new FileSystemEventHandler(watcher_Changed);
            // etc..
        }
        public string Path {
            get { return watcher.Path; }
            set { watcher.Path = value; }
        }
        // etc..
    }
