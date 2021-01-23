    if (openFileDialog1.ShowDialog() == DialogResult.OK)
    {
        System.IO.StreamReader sr = new System.IO.StreamReader(openFileDialog1.FileName);
        richTextBox1.Text = sr.ReadToEnd();
        sr.Close();
    }
