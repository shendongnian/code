    public Form1()
    {
      InitializeComponent();
      var p = new Panel();
      p.Size = new System.Drawing.Size(360, 500);
      p.BorderStyle = BorderStyle.FixedSingle;
      p.Name = "panel";
      var tpanel = new TableLayoutPanel();
      tpanel.Name = "tablepanel";
      ListBox lb = new ListBox();
      tpanel.Controls.Add(lb = new ListBox() { Text = "qtylistBox2" }, 1, 3);
      Label l6 = new Label();
      tpanel.Controls.Add(l6 = new Label() { Text = "0" }, 2, 1);
      //here is the timer that i created
      var timer1 = new Timer();
      timer1.Interval = 1000;
      timer1.Tick += (sender, e) => { l6.Text = DateTime.Now.ToString("mm\\:ss"); };
      timer1.Enabled = true;
    }
