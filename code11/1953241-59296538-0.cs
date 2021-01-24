    private void btCurrentWeek_Click(object sender, EventArgs e)
    {
        for (int i = 1; i <= 7; i++)
        {
            string date = DateTime.Now.Date.AddDays(-(int)(DateTime.Now.DayOfWeek) + i).ToShortDateString();
            string dayOfWeek = DateTime.Now.Date.AddDays(-(int)(DateTime.Now.DayOfWeek) + i).DayOfWeek.ToString();
            dataGridView1.Columns[i - 1].HeaderText = dayOfWeek + "\n" + date;
        }
    }
