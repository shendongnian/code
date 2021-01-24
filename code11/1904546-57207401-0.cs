private void SubmitShortcut(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter && e.Control)
            {
                e.Handled = true;
                SubmitBtn_Click(sender, e);
            }
            else if (e.KeyCode != Keys.Enter && e.Control)
            {
                e.Handled = false;
            }
        }
