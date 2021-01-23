    private int pickedbox = 0
    [...]
    private void textBox1_Enter(...)
    {
        pickedbox = 0;
    }
    private void textBox2_Enter(...)
    {
        pickedbox = 1;
    }
    private void button1_Click(...)
    {
        switch(pickedbox)
        {
            case 0:
                textBox1.Text = int.Parse(textBox1.Text)++;
                break;
            case 1:
                textBox2.Text = int.Parse(textBox2.Text)++;
                break;
        }
    }
