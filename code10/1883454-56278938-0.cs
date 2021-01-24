    private void Form_Load(object sender, EventArgs e)
    {
        for (int i = 0; i < 10; i++)
        {
            var btn = new Button
            {
                Text = "Button #" + i, Top = i * 50, Left = 0
            };
            btn.Click += btn_Click;
            this.Controls.Add(btn);
        }
    }
    
    private void btn_Clicked(object sender, EventArgs e)
    {
        MessageBox.Show(((Button)sender).Text); // Access the clicked button by `sender`
    }
