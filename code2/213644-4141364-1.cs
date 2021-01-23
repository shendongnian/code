    public void writetext()
    {
        using (TextWriter writer = new StreamWriter("filename.txt", true))  // true is for append mode
        {
            writer.WriteLine("First name, {0} Lastname, {1} Phone,{2} Day of birth,{3}", textBox1.Text, textBox2.Text, maskedTextBox1.Text, textBox4.Text);
        }
    }
