        private void Form1_Load(object sender, EventArgs e)
        {
            // Create spacer tab with a name long enough to reach the 200px mark
            TabPage spacer = new TabPage("..............................................................");
            tabControl1.TabPages.Insert(0, spacer);
            // Create a panel at the same location of the tab control.
            Panel spacerBlock = new Panel();
            spacerBlock.Name = "spacer";
            spacerBlock.Location = tabControl1.Location;
            spacerBlock.Width = 198;
            spacerBlock.Height = 20;
            this.Controls.Add(spacerBlock);
            spacerBlock.BringToFront();
        }
        
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Ensure the user can't use the keyboard to somehow select the spacer tab.
            if (tabControl1.SelectedIndex == 0)
                tabControl1.SelectedIndex = 1;
            // Check if the second (first I guess) tab is selected and adjust the panel to keep the look consistant.
            if (tabControl1.SelectedIndex == 1)
                this.Controls["spacer"].Width = 198;
            else
                this.Controls["spacer"].Width = 200;
        }
