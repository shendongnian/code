    class Foo {
        private readonly object o;
        public Foo(object o) {
            this.o = o;
        }
        public void OnCreated(object sender, FileSystemEventArgs e) {
            Console.WriteLine(this.o);
            // handle event
        }
    }
    object o = null;
    Foo foo = new Foo(o);
    var watcher = new FileSystemWatcher();
    watcher.Created += foo.OnCreated;
