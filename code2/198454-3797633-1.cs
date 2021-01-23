    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (this.DialogResult == DialogResult.OK)
        {
            if (!IsValid())
            {
                Info("Invalid data");
                e.Cancel = true;
            }
            else
            {
                Info("Valid data found, closing dialog");
            }
        }
        else if (this.DialogResult == DialogResult.Cancel)
        {
            Info("Just cancelling!");
        }
    }
