    private void textBox1_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            //Check if the Text has changed and set the other fields. Reset the textchanged flag
            Console.WriteLine("Enter Key:" + textBox1.Text);
        }
        else if (e.KeyCode == Keys.Down)
        {
            //Check if the Text has changed and set the other fields. Reset the textchanged flag
            Console.WriteLine("Key Down:" + textBox1.Text);
        }
    }
    
    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        //this event is fired first. Set a flag to record if the text changed. 
        Console.WriteLine("Text changed:" + textBox1.Text);
    }
