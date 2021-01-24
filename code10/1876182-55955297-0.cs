    private void Form1_Load(object sender, EventArgs e)
    {
        for (int i = 0; i < 5; i++)
        {
            //Let's put 5 buttons on the form
            Button btn = new Button();
            btn.Location = new Point(10, i * 25);
            btn.Name = "btn" + i;
            btn.Text = "Closed";
            //Add a Click EventHandler
            btn.Click += new EventHandler(btn_Click);
            //Add a MouseUp MouseEventHandler
            btn.MouseUp += new MouseEventHandler(btn_MouseUp);
            //Add them to the form
            Controls.Add(btn);
        }
    }
    private void btn_MouseUp(object sender, MouseEventArgs e)
    {
        Button b = sender as Button;
        //Show me which button was used when this event was triggered
        //MessageBox.Show(e.Button.ToString() + " Mouse button was used.");
        //Since the Right button on mouseup will not be considered a Click, we can tell it to PerformClick
        if (e.Button == MouseButtons.Right)
        {
            b.PerformClick();
        }
    }
    private void btn_Click(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        btn.Text = "Opened";
        
    }
