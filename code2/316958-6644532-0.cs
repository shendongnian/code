    public string filePath;
    public void button1_Click(object sender, EventArgs e)
    {
        OpenFileDialog OFD = new OpenFileDialog();
        OFD.Title = "Choose a Plain Text File";
        OFD.Filter = "Text File | *.txt";
        OFD.ShowDialog();
        filePath = OFD.FileName;
        if (OFD.FileName != "") {
            using (StreamReader reader = new StreamReader(@filePath))
            {
                while (!reader.EndOfStream)
                {
                    richTextBox1.AppendText(reader.ReadLine());
                }
                reader.Close();
            }
        }
    }
    public void button2_Click(object sender, EventArgs e)
    {
        // you should test a value of filePath (null, string.Empty)
        using (StreamWriter writer = new StreamWriter(@filePath)){
            writer.WriteLine(richTextBox1.Text);
            writer.Close();
        }
    }
