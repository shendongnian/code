    ObservableCollection<User> Users { get; set; }
    void LoadUsers()
    {
        int _Size = 10;
        int _Page = 0;
        List<User> _Data;
        using (System.ComponentModel.BackgroundWorker _Worker
            = new System.ComponentModel.BackgroundWorker())
        {
            _Worker.DoWork += (s, arg) =>
            {
                _Data = GetData(_Size, _Page++);
                _Worker.ReportProgress(_Page);
                while (_Data.Any())
                {
                    _Data = GetData(_Size, _Page++);
                    _Worker.ReportProgress(_Page);
                }
            };
            _Worker.ProgressChanged += (s, arg) =>
            {
                // update the observable on the ui thread
                _Data.ForEach(x => Users.Add(x));
            };
            _Worker.RunWorkerAsync();
        }
    }
    List<User> GetData(int size, int page)
    {
        return m_Context.Users.Take(size).Skip(page).ToList();
    }
