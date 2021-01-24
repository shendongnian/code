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
      Action<string, int, int> createLabel = (text, x, y) =>
      {
        var label = new Label();
        label.Text = text;
        tpanel.Controls.Add(label, x, y);
        var timer = new Timer();
        timer.Interval = 1000;
        timer.Tick += (sender, e) => { label.Text = DateTime.Now.ToString("mm\\:ss"); };
        Timers.Add(timer);
        timer.Enabled = true;
      };
      // create one label
      createLabel("0", 2, 1);
      // create other label
      // createLabel("", 0, 0);
    }
