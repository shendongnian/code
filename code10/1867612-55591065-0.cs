    private int _score = 0;
    private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                _score += 1;
                label1.Text = _score.ToString();
            }
    private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked)
            {
                _score += 1;
                label1.Text = _score.ToString();
            }
