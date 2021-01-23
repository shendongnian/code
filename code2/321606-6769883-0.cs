        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            toolStripButton1.BackColor = Color.FromKnownColor(KnownColor.Control);
            toolStripButton1.Enabled = false;
        }
        private void toolStripButton1_MouseEnter(object sender, EventArgs e)
        {
            toolStripButton1.BackColor = Color.Red;
        }
        private void toolStripButton1_MouseLeave(object sender, EventArgs e)
        {
            toolStripButton1.BackColor = Color.FromKnownColor(KnownColor.Control);
        }
