    for (int i = 0; i < 2; i++)
    {
        Label label = new Label();
        label.Width = 95;
        label.Location = new Point(x + (i * label.Width) + (i * 10), y);
        label.BackColor = Color.PaleVioletRed;
        label.ForeColor = Color.AntiqueWhite;
        label.TextAlign = ContentAlignment.MiddleCenter;
        label.Name = "isMale-isFemale".Split('-')[i];
        label.Text = label.Name;
        label.MouseClick += (s, ev) =>
        {
            var lbl = (s as Control);
            string other = lbl.Name.Equals("isFemale") ? "isMale" : "isFemale";
            lbl.BackColor = Color.GreenYellow;
            lbl.ForeColor = Color.Black;
            var ctl = this.Controls[other];
            if (ctl != null)
            {
                ctl.BackColor = Color.PaleVioletRed;
                ctl.ForeColor = Color.AntiqueWhite;
            }
        };
        this.Controls.Add(label);
    }
