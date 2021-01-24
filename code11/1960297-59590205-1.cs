    public partial class MyService : ServiceBase
    {
        FileSystemWatcher watcher1;
        FileSystemWatcher watcher2;
        FileSystemWatcher watcher3;
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                watcher1?.Dispose();
                watcher2?.Dispose();
                watcher3?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
