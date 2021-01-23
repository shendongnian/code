        public FileStream(string path, FileMode mode, FileAccess access, FileShare share, int unused)
        {
            IsolatedStorageFileStream handler = null;
            if (FileStream.HandleTracker.TryGetValue(path, out handler))
            {
                _internal = handler;
            }
            else
            {
                if (mode == FileMode.Create || mode == FileMode.CreateNew)
                {
                    _internal = IsolatedStorageIO.Default.CreateFile(path);
                }
                else
                {
                    _internal = IsolatedStorageIO.Default.OpenFile(path, FileMode.OpenOrCreate);
                }
                FileStream.HandleTracker.Add(path, _internal);
            }
        }
