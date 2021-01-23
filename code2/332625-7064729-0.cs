    private void Form1_Load(object sender, EventArgs e)
    {
        blabla = "anything";
        Button btn = new Button();
        btn.Location = new Point(10, 40);
        btn.Text = "Click me";
        btn.Click += (s,e) => MessageBox.Show(blabla);
        this.Controls.Add(btn);
    }
