    private void deleteCurrentScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveControl is TextBox)
            {
                this.panel1.Controls.Remove(ActiveControl);
                
            }
        }
