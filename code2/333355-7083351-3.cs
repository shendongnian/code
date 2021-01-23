    ObservableCollection<User> Users { get; set; }
    void LoadUsers()
    {
        int _Size = 10;
        int _Page = 0;
        List<User> _Data = null;
        using (System.ComponentModel.BackgroundWorker _Worker
            = new System.ComponentModel.BackgroundWorker())
        {
            _Worker.DoWork += (s, arg) =>
            {
                _Data = GetData(_Size, _Page++);
            };
            _Worker.RunWorkerCompleted += (s, arg) =>
            {
                if (!_Data.Any())
                    return;
                // update the observable on the ui thread 
                _Data.ForEach(x => Users.Add(x));
                // get any more data
                _Worker.RunWorkerAsync();
            };
            _Worker.RunWorkerAsync();
        }
    }
    List<User> GetData(int size, int page)
    {
        // never return null
        return m_Context.Users.Take(size).Skip(page).ToList();
    }
