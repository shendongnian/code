    private void Form1_Load(object sender, EventArgs e)
    {
        
        Button btn = new Button();
        btn.Location = new Point(10, 40);
        btn.Text = "Click me";
        btn.Click += new EventHandler(btn_Click);
        btn.Tag = "blahblah";
        this.Controls.Add(btn);
    }
    void btn_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        MessageBox.Show(btn.Tag.ToString());
    }
