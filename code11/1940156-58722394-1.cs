    while(true)
    {
        this.Dispatcher.Invoke(new Action(() =>
        {
            string time = System.DateTime.Now.ToString() + "\n";
            Run r = new Run(time);
            p.Inlines.Add(r);
        }));
        System.Threading.Thread.Sleep(1000);
    }
