    private void button1_Click(object sender, EventArgs e)
    {
            if (this.Dock != DockStyle.None)
            {
                this.Dock = DockStyle.None;
                MessageBox.Show("Dockstyle is None");
            }
            else
            {
                this.Dock = DockStyle.Left;
                MessageBox.Show("Dockstyle is Left");
            }
    }
