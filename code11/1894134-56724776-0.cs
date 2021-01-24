    public Form1()
    {
        InitializeComponent();
        this.MouseMove += Form1_MouseMove;
    }
    private void Form1_MouseMove(object sender, MouseEventArgs e)
    {
        coolTextBox.Visible = coolTextBox.ClientRectangle.Contains(coolTextBox.PointToClient(Cursor.Position));       
    }
