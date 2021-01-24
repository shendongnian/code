    private List<Timer> Timers = new List<Timer>();
    public Form1()
    {
      InitializeComponent();
      var p = new Panel();
      p.Size = new Size(360, 500);
      p.BorderStyle = BorderStyle.FixedSingle;
      p.Name = "panel";
      var tpanel = new TableLayoutPanel();
      tpanel.Name = "tablepanel";
      ListBox lb = new ListBox();
      tpanel.Controls.Add(lb = new ListBox() { Text = "qtylistBox2" }, 1, 3);
      Action<Label> createTimer = label =>
      {
        var timer = new Timer();
        timer.Interval = 1000;
        timer.Tick += (sender, e) => { label.Text = DateTime.Now.ToString("mm\\:ss"); };
        timer.Enabled = true;
        Timers.Add(timer);
      };
      Label label;
      // create one label
      tpanel.Controls.Add(label = new Label() { Text = "0" }, 2, 1);
      createTimer(label);
      // create other label
      // ...
      // createTimer(other label);
    }
