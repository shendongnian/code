    private void line_MouseClick(object sender, MouseEventArgs)
    {
        foreach (Control control in myListBox.Controls)
            if (control is Panel)
                if (control == sender)
                    control.BackColor = Color.DarkBlue;
                else
                    control.BackColor = Color.Transparent;      
    }
