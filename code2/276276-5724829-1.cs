    private void Form1_Load(object sender, EventArgs e)
        {
            // initialize datagrid with some values
            GlowDataGrid.Rows.Add(5);
            string[] names = new string[] { "Mary","James","Michael","Linda","Susan"};
            for(int i = 0; i < 5; i++)
            {
                GlowDataGrid[0, i].Value = names[i];
                GlowDataGrid[1, i].Value = i;
            }
        }
        private void GlowButton_Click(object sender, EventArgs e)
        {
            // set third row's back color to yellow
            GlowDataGrid.Rows[2].DefaultCellStyle.BackColor = Color.Yellow;
            // set glow interval to 2000 milliseconds
            GlowTimer.Interval = 2000;
            GlowTimer.Enabled = true;
        }
        private void GlowTimer_Tick(object sender, EventArgs e)
        {
            // disable timer and set the color back to white
            GlowTimer.Enabled = false;
            GlowDataGrid.Rows[2].DefaultCellStyle.BackColor = Color.White;
        }
