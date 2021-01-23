    public Form1()
    {
        InitializeComponent();
        MouseClick += new MouseEventHandler(Form1_MouseClick);
    }
    private void Form1_MouseClick (object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {
            ContextMenuStrip ctxMenu = new ContextMenuStrip();
            // following line creates an anonymous delegate
            // and captures the "e" MouseEventArgs from 
            // this method
            ctxMenu.Items.Add(new ToolStripMenuItem(
               "Insert info", null, (s, args) => InsertInfoPoint(e.Location)));
            ctxMenu.Show(this, e.Location);
        }
    }
    private void InsertInfoPoint(Point location)
    {
        // insert actual "info point"
        Label lbl = new Label()
        {
            Text = "new label",
            BorderStyle = BorderStyle.FixedSingle,
            Left = location.X, Top = location.Y
        };
        this.Controls.Add(lbl);
    }
