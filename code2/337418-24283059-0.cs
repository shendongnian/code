    private void chart1_MouseMove(object sender, MouseEventArgs e)
    {
        lab_X_Axis.Location = new Point((e.X), 21);
        lab_Y_Axis.Location = new Point(76, e.Y);
    }
    private void Form1_Load(object sender, EventArgs e)
    {
        lab_X_Axis.AutoSize = false;
        lab_Y_Axis.AutoSize = false;
        lab_X_Axis.Text="";
        lab_Y_Axis.Text="";
        lab_X_Axes.Size = new Size(1, 300);
        lab_Y_Axes.Size = new Size(300, 1);
    }
