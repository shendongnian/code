    public void writeToTextBoxEvent(object sender, System.Diagnostics.DataReceivedEventArgs e)
    {
        // Write it as a single line
        this.textBox1.SafeBeginInvoke(new Action(() => textBox1.Text = e.Data));
        this.textBox1.SafeBeginInvoke(new Action(() =>
            {
                //Write it with multiple lines
                textBox1.Text = e.Data;
            }));
    }
