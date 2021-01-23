    private bool _canShow = false;
    private Timer _timer;
    public Form1()
    {
      InitializeComponent();
      _timer = new Timer();
      _timer.Interval = 5000;
      _timer.Tick += new EventHandler(timer_Tick);
      _timer.Enabled = true;
    }
    void timer_Tick(object sender, EventArgs e)
    {
      _canShow = true;
      Visible = true;
    }
    protected override void SetVisibleCore(bool value)
    {
      if (_canShow)
      {
        base.SetVisibleCore(value);
      }
      else
      {
        base.SetVisibleCore(false);
      }
    }
