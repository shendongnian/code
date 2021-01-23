    void Main()
    {
        // trigger some background work
        ...
        // and start the message pump
        Application.Run();
    }
    void SomeBackgroundWork()
    {
        // let's say now you completed the background work and you want to show your main Form
        MyForm f = new MyForm();
        f.Close += delegate { Application.Exit(); };
        f.Show();
    }
