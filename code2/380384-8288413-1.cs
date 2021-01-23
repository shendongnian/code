    private void button2_Click(object sender, EventArgs e)
    {
        fs.Seek(0,0);
        fs.SetLength(Encoding.UTF8.GetBytes(textbox.Text).Length));
        StreamWriter sw = new StreamWriter(fs);
        sw.Write(textbox.Text);
        sw.Flush();
    }
