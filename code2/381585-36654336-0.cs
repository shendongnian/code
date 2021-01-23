            if (e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space))
            {
                ErrorLbl.Text = "ERROR : Wrong input";
            }
            else ErrorLbl.Text = string.Empty;
            if (ErrorLbl.Text == errmsg)
            {
                Nametxt.Text = string.Empty;
            }
