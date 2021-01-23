    private bool SuppressRadioButton1Event { get; set; }
    private void radioButton1_CheckedChanged(object sender, EventArgs e)
    {
        if (!this.SuppressRadioButton1Event)
        {
            MessageBox.Show("Not suppressed!");
        }
    }
    private void button1_Click(object sender, EventArgs e)
    {
        this.SetRadioButton1(false);
    }
    private void SetRadioButton1(bool checkedOn)
    {
        this.SuppressRadioButton1Event = true;
        radioButton1.Checked = checkedOn;
        this.SuppressRadioButton1Event = false;
    }
