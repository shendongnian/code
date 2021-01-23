    string last = string.Empty;
    private void button6_Click(object sender, EventArgs e)
        {
            string x = //some varying value I get from other parts of my program
            if(x!=last)
            {
                listBox1.Items.Clear();
                listBox1.Items.Add(x + /*other things*/);
                last = x;
            }
        }
