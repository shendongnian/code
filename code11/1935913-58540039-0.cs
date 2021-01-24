    public class Form1
    {
        FileSystemWatcher _watcher;
       
        public Form1()
        {
            ...
            _watcher=CreateDormantWatcher(path,pattern);
            _watcher.EnableRaisingEvents=true ;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            _watcher.EnableRaisingEvents =false;
            Directory.Delete("Alpha", true);//Recursively Delete
        }
        protected override void Dispose (bool disposing)
        {
            if (disposing)
            {
                 _watcher.Dispose();
            }
            _watcher=watcher;
        }
        FileSystemWatcher CreateDormantWatcher(string path,string pattern)
        {
            //Don't store to the field until the FSW is 
            //already configured
            var watcher=new FileSystemWatcher()
            {
                Path = path,
                Filter = "pattern,
                NotifyFilter = NotifyFilters.FileName
            };
            watcher.Changed += OnChanged;
            watcher.Created += OnCreated;
            watcher.Deleted += OnChanged;
            watcher.Renamed += OnRenamed;
            return watcher;
        }
