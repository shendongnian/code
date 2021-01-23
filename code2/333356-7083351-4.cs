    ObservableCollection<User> Users { get; set; }
    void LoadUsers()
    {
        int _Size = 2;
        int _Page = 0;
        using (System.ComponentModel.BackgroundWorker _Worker
            = new System.ComponentModel.BackgroundWorker())
        {
            _Worker.WorkerReportsProgress = true;
            _Worker.DoWork += (s, arg) =>
            {
                List<User> _Data = null;
                while (_Data == null || _Data.Any())
                {
                    _Data = GetData(_Size, _Page++);
                    _Worker.ReportProgress(_Page, _Data);
                }
            };
            _Worker.ProgressChanged += (s, e) =>
            {
                List<User> _Data = null;
                _Data = e.UserState as List<User>;
                _Data.ForEach(x => Users.Add(x));
            };
            _Worker.RunWorkerAsync();
        }
    }
    List<User> GetData(int size, int page)
    {
        // never return null
        return m_Context.Users.Take(size).Skip(page).ToList();
    }
