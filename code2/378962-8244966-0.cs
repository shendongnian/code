    buttonName = "btn" + y.ToString() + x.ToString();
    Button btn = this.Controls.Find(buttonName, true)[0] as Control;
    btn.BackColor = System.Drawing.Color.Blue;
    btn.FlatStyle = FlatStyle.Flat
    btn.FlatAppearance.BorderColor = Color.Red;
    btn.FlatAppearance.BorderSize = 1;
