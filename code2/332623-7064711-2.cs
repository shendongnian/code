    private void Form1_Load(object sender, EventArgs e)
    {
        string blabla = "anything";
        Button btn = new Button();
        btn.Location = new Point(10, 40);
        btn.Text = "Click me";
        btn.Click += delegate {
            MessageBox.Show(blabla);
            // Other code here, but hopefully not too much...
        };
        this.Controls.Add(btn);
    }
