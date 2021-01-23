     private void AllTextBoxes_MouseClick(object sender, MouseEventArgs e)
            {
                if(sender is TextBox)
                    ((TextBox)(sender)).Text = "";
            }
