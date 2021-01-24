    private void button_Click(object sender, EventArgs e)
            {
                var btn = (Control)sender;
    
                btn.Enabled = false;
                btn.BackColor = Color.LightGray;
    
                // Where is this button in the form?
                var indexOfThisButton = this.Controls.IndexOf(btn);
    
                // Find next button index
                for (int i = indexOfThisButton+1; i < this.Controls.Count; i ++)
                {
                    // If it's a button, select it
                    if (this.Controls[i] is Button)
                    {
                        this.Controls[i].Select();
                        return;
                    }
                }
    
                // If we got down here we have got to the end of the controls list, start again
                for (int i = 0; i < this.Controls.Count; i++)
                {
                    // If it's a button, select it
                    if (this.Controls[i] is Button)
                    {
                        this.Controls[i].Select();
                        return;
                    }
                }
            }
