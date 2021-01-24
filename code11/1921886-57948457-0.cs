    private void Submit_Click(object sender, EventArgs e)
    {
        if (textBox_Name.Text == "OptionA" || textBox_Name.Text == "OptionB")
            MessageBox.Show("Good job, at least you know your own name, LOL");
        else 
        {
            string message = "Your name is not " + textBox_Name.Text;
            string caption = "Error input";
            MessageBoxButtons buttons = MessageBoxButtons.RetryCancel;
            MessageBox.Show(message, caption, buttons);
            textBox_Name.Clear();
        }
    }
