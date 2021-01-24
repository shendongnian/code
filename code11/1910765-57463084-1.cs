    private Timer timer;
    public Form1()
    {
        InitializeComponent();
        this.Paint += Form1_Paint;
        this.KeyPreview = true;
        this.KeyDown += Form1_KeyDown;
        // setup a timer which will call Timer_Tick every 100ms
        timer = new System.Windows.Forms.Timer();
        timer.Interval = 100;
        timer.Tick += Timer_Tick;
        timer.Start();
        this.player = new Player(new Size(8, 8));
        this.bots = new List<Bot>();
        for (int i = 0; i < 30; i++)
        {
            Bot bot = new Bot(player, new Size(8, 8));
            bot.Follow();
            this.bots.Add(bot);
        }
    }
    private void Timer_Tick(object sender, System.EventArgs e)
    {
        foreach (var bot in bots)
            bot.Follow();
        this.Invalidate();
    }
