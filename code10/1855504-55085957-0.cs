    private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
    {
        DoSomething(dateTimePicker1.Value);
    }
    void DoSomething(DateTime date)
    {
        MessageBox.Show(date.ToString());
    }
