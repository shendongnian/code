    private void button1_Click(object sender, EventArgs e)
    {
        for (int i = 1; i < 10; i++)
        {
            Button btn = new Button();
            btn.Text = "btn" + i.ToString();
            btn.Tag = i;
            btn.Click += delegate
            {
                if ((int)btn.Tag == 1)
                    this.Text = "stack";
            };
            this.flowLayoutPanel1.Controls.Add(btn);
        }
    }
