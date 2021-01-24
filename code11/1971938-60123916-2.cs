    private void button1_Click_1(object sender, EventArgs e)
    {
        int f = 0, t = 0;
        if (Int32.TryParse(textBox1.Text, out f))
        {
            // successfully parsed 
        }
        if (Int32.TryParse(textBox3.Text, out t))
        {
            // successfully parsed 
        }
        // or just use parse..
        int f1 = Int32.Parse(textBox1.Text);
        int t1 = Int32.Parse(textBox3.Text);
        if (rangeCheck(f, t))
        {
           // Success 
        }
    }
    bool rangeCheck(int first, int third)
    {
        return (first >= 0 && first <= 100 && third >= 0 && third <= 100);
    }
