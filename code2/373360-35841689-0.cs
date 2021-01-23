     private void Form1_Resize(object sender, EventArgs e)
            {
                foreach (Control control in MasterPanel.Controls)
                {
                    control.Size = MasterPanel.Size;
                }
    
            }
