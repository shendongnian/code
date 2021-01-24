    for (int i = 0; i < 10; i++)
    {
        Button btn = new Button();
        btn.Name = "btnAdi" + (i + 1).ToString();
        btn.Text = (i + 1).ToString();
        this.Controls.Add(btn);
        btn.Location = new Point(0, btn.Height * i);
    
        Label lbl = new Label()
        {
            TextAlign = ContentAlignment.MiddleLeft,
            Dock = DockStyle.None,
            BorderStyle = BorderStyle.FixedSingle,
        };
        lbl.AutoSize = true;
        lbl.Text = btn.Name.ToString();
    
        this.Controls.Add(lbl);
        lbl.Location = new Point(btn.Width, (btn.Height * i));
    }
