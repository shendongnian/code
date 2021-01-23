    private void button4_Click(object sender, EventArgs e)
    {
        string[] lines = File.ReadAllLines("filename.txt");
        string result = GetResultFromLines(lines, textBox5.Text);
        label7.Text = (String.Format("Month of Birth{0}", result)); 
    }
