    private void yourForm_Load(object sender, EventArgs e)
        {
            textBox1.Multiline = true;
        }
    //then write your TextBox codes
    private void textBox1_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            // doSomething();
        }
    }
