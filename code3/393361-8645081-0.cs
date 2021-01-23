    public Form1()
    {
        InitializeComponent();
        const int maxWidth = 200;
        const int maxTicks = 10;
        var currentTick = 0;
        // Create panel and add it to this form
        var panel = new Panel { Location = new Point(1, 1), BackColor = Color.Blue, Width = 0, Height = 5 };
        Controls.Add(panel);
        // Create timer that handles updates
        var t = new Timer { Interval = 1000 };
        t.Tick += delegate
        {
            panel.Width = maxWidth / maxTicks * currentTick;
            if (currentTick++ != maxTicks)
                return;
            panel.BackColor = Color.Green;
            t.Dispose();
        };
        t.Start();
    }
