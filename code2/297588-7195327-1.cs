        private void SummaryData_Resize(object sender, EventArgs e)
        {
            foreach (MyPanel pan in this.Controls)
            {
                pan.Dock = DockStyle.Fill;
            }
        }
