    private void Process_MouseEnter(object sender, EventArgs e)
    {
        int count = 0;
        Panel p = null;
    
        if (sender is Panel)
        {
            p = sender as Panel;
    
            // Compute the count using data stored in Label.Tag
            foreach (Control c in p.Controls)
                if (c is Label)
                {
                    Label l = c as Label;
                    l.Text = (((int)l.Tag) + 1).ToString();
                    l.Tag = (int)l.Tag + 1;
                    count = (int)l.Tag;
                    break;
                }
    
            //set backcolor of control based on tag number             
            p.BackColor = (p.BackColor == Color.White) ? Color.LightGray : Color.White;
            if (count >= 20) p.BackColor = Color.Red;
            else if (count >= 15) p.BackColor = Color.Yellow;
            else if (count >= 10) p.BackColor = Color.Lime;
            else if (count >= 5) p.BackColor = Color.Cyan;
            else p.BackColor = Color.SlateBlue;
    
        } /* end Panel if */
    
    
        if (sender is Label)
        {
            Label l = sender as Label;
            l.Text = (((int)l.Tag) + 1).ToString();
            l.Tag = (int)l.Tag + 1;
            count = (int)l.Tag;
    
            //set backcolor of control based on tag number             
            p = l.Parent as Panel;
            p.BackColor = (p.BackColor == Color.White) ? Color.LightGray : Color.White;
            if (count >= 20) p.BackColor = Color.Red;
            else if (count >= 15) p.BackColor = Color.Yellow;
            else if (count >= 10) p.BackColor = Color.Lime;
            else if (count >= 5) p.BackColor = Color.Cyan;
            else p.BackColor = Color.SlateBlue;
        } /* end Label if */
    }
