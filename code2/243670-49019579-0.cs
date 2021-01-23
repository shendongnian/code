    private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
    {
        int s = System.DateTime.DaysInMonth(DateTimePicker1.Value.Date.Year, DateTimePicker1.Value.Date.Month);
        TextBox1.Text = s.ToString();
    } 
