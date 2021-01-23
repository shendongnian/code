        public FileStream(string path, FileMode mode, FileAccess access, FileShare share, int unused)
        {
            IsolatedStorageFileStream handler = null;
            if(FileStream.HandleTracker.TryGetValue(path, out handler)) 
            {
                _internal = handler;
                if(!_internal.CanRead) 
                {
                    FileStream.HandleTracker.Remove(path);
                    CreateOpenNewFile(path, mode);
                }
            } else {
                CreateOpenNewFile(path, mode);
            }
        }
        private void CreateOpenNewFile(string path, FileMode mode) 
        {
            if(mode == FileMode.Create || mode == FileMode.CreateNew) 
            {
                _internal = IsolatedStorageIO.Default.CreateFile(path);
            } else {
                try {
                    _internal = IsolatedStorageIO.Default.OpenFile(path, FileMode.OpenOrCreate);
                } catch(Exception ex) {
                    var v = ex;
                }
            }
            FileStream.HandleTracker.Add(path, _internal);
        }
