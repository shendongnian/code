    private Dictionary<Timer, DateTime> Timers = new Dictionary<Timer, DateTime>();
    public Form1()
    {
      InitializeComponent();
      var p = new Panel();
      p.Size = new Size(360, 500);
      p.BorderStyle = BorderStyle.FixedSingle;
      p.Name = "panel";
      Controls.Add(p);
      var tpanel = new TableLayoutPanel();
      tpanel.Name = "tablepanel";
      tpanel.Controls.Add(new ListBox() { Text = "qtylistBox2" }, 1, 3);
      p.Controls.Add(tpanel);
      Action<string, int, int> createLabel = (text, x, y) =>
      {
        var label = new Label();
        label.Text = text;
        tpanel.Controls.Add(label, x, y);
        var timer = new Timer();
        timer.Interval = 1000;
        timer.Tick += (sender, e) => 
        {
          label.Text = DateTime.Now.Subtract(Timers[sender as Timer]).ToString("mm\\:ss");
        };
        Timers.Add(timer, DateTime.Now);
      };
      // create one label
      createLabel("0", 2, 1);
      // create other label
      // createLabel("", 0, 0);
      foreach ( var item in Timers )
        item.Key.Enabled = true;
    }
