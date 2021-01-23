    StreamReader sr = new StreamReader("@c:\MyBigFile.log");
    string line = sr.ReadLine();
    while (line != null)
    {
        if(line.Contains("Error"))
        {
            richTextBox.Text += line + Environment.NewLine;
        }
        line = sr.ReadLine();
    }
    sr.Close();
    
