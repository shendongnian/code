    private void button1_Click(object sender, EventArgs e)
        {          
            foreach (var line in textBox1.Lines)
            {
                if (line.Contains("hello"))
                {
                   textBox1.Text= textBox1.Text.Replace(line, "This is new line");
                }
            }
        }
