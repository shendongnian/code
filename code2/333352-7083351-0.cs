    ObservableCollection<User> Users { get; set; }
    void LoadUsers()
    {
        int _Size = 10;
        int _Page = 1;
        using (System.ComponentModel.BackgroundWorker _Worker 
            = new System.ComponentModel.BackgroundWorker())
        {
            _Worker.DoWork += (s, arg) =>
            {
                arg.Result = GetData(_Size, _Page);
            };
            _Worker.RunWorkerCompleted += (s, arg) =>
            {
                var _Data = arg.Result as List<User>;
                if (_Data.Any())
                {
                    _Data.ForEach(x => Users.Add(x));
                    _Data = GetData(_Size, _Page++);
                    _Worker.RunWorkerAsync();
                }
            };
            _Worker.RunWorkerAsync();
        }
    }
    List<User> GetData(int size, int page)
    {
        return m_Context.Users.Take(size).Skip(page).ToList();
    }
