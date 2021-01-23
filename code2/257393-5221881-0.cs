    // this is the click event on my search button
    private void FindUser_Click(object sender, EventArgs e)
    {
        this.UserListSearch.Enabled = false;
        this.UserListSearch.Items.Clear();
        Model.FindUser(FindText.Text.ToUpper(), userlist =>
        {
            foreach (User u in userlist)
            {
                ListViewItem item = new ListViewItem(u.UserName);
                item.Name = u.UserName;
                item.SubItems.Add(u.Description);
                this.UserListSearch.Items.Add(item);
            }
            this.UserListSearch.Enabled = true;
        });
    }
    // this is the function I call when I need async call
    public void FindUser(string text, Action<User[]> callback)
    {
        CreateBackgroundWorker<User[]>(() =>
            {
                ServiceUsersClient client = new ServiceUsersClient();
                var results = client.FindUser(text);
                client.Close();
                return results;
            }, callback);
    }
    // this is my utility function to create a bgworker "on demand"
    private void CreateBackgroundWorker<T>(Func<T> dowork, Action<T> callback)
    {
        BackgroundWorker worker = new BackgroundWorker();
        worker.DoWork += (sender, args) =>
        {
            T result = dowork.Invoke();
            (callback.Target as Form).Invoke(callback, result);
        };
        worker.RunWorkerAsync();
    }
