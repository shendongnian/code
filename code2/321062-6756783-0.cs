    comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int i = 0;  
        int y = 0;
        while (i < int.Parse(comboBox1.SelectedItem.ToString()))
        {
            System.Windows.Forms.TextBox tt = new System.Windows.Forms.TextBox();
            y = y + 30;
            tt.Location = new System.Drawing.Point(0, y);
            this.Controls.Add(tt);
            i++;
        }
    }
