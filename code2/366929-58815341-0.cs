    private int interval = 0;
    private string message = "";
    public msgBox(string msg = "", int i = 0)
    {
        InitializeComponent();
        interval = i;
        message = msg;
    }
    private void MsgBox_Load(object sender, EventArgs e)
    {
        if (interval > 0)
            timer1.Interval = interval;
        lblMessage.Text = message;
        lblMessage.Width = panel1.Width - 20;
        lblMessage.Left = 10;
    }
    private void Timer1_Tick(object sender, EventArgs e)
    {
        this.Close();
    }
    private void Panel1_Paint(object sender, PaintEventArgs e)
    {
        ControlPaint.DrawBorder(e.Graphics, this.panel1.ClientRectangle, Color.DarkBlue, ButtonBorderStyle.Solid);
    }
