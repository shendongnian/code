    private void mainForm_Load(object sender, EventArgs e)         
    {        
        Task t1 = Task.Factory.StartNew<int>(Func1).ContinueWith(t => { currentCount = t.Result; UpdateLabel(); });
        Task t2 = Task.Factory.StartNew<int>(Func2).ContinueWith(t => { allowedCount = t.Result; UpdateLabel(); });
    }
