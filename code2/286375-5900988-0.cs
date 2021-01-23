        private void UserControl1_MouseHover(object sender, EventArgs e) {
            this.BackColor = Color.Green; // For a Green border.
        }
        private void UserControl1_MouseLeave(object sender, EventArgs e) {
            this.BackColor = SystemColors.Control;  // Default color.
        }
