    private void numericUpDown1R2Scrap_ValueChanged(object sender, EventArgs e)
    {
        NumericUpDown nUpDown = sender as NumericUpDown;
        if (nUpDown.Value == 0) nUpDown.Value = 1;
        if (decimal.TryParse(textBox1WeightSummary.Text, out decimal inputValue)) {
            textBox1RingWeightTotal.Text = (inputValue / nUpDown.Value).ToString();
        }
    }
