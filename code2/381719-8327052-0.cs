    private void btnDump_Click(object sender, EventArgs e)
    {
        using (StreamWriter sw = new StreamWriter("E:\\TestFile.txt"))
        {
            // Add some text to the file.
            sw.WriteLine(txtChange.Text + "\r\n");
        }
    }
