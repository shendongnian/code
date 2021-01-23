    private long currentPosition = 0;
    private void UpdateProgressBar(int lineLength)
    {
        currentPosition += line.Count; // or plus 2 if you need to take into account carriage return
        progressBar.Value = (int)(((decimal)currentPosition / (decimal)length) * (decimal)100);
    }
    private void CopyFile()
    {
        progressBar.Minimum = 0;
        progressBar.Maximum = 100;
        currentPosition = 0;
        using (StreamReader sr = new StreamReader(file,System.Text.Encoding.ASCII))
        {
            while (sr.EndOfStream == false)
            {
                line = sr.ReadLine();
                UpdateProgressBar(line.Length);
                if (line.IndexOf(start) != -1)
                {
                    using (StreamWriter sw = new StreamWriter(DateTime.Now.ToString().Replace("/", "-").Replace(":", "-") + "cut"))
                    {
                        sw.WriteLine(line);
                        while (sr.EndOfStream == false && line.IndexOf(end) == -1)
                        {
                            line = sr.ReadLine();
                            UpdateProgressBar(line.Length);
                            sw.WriteLine(line);
                        }
                    }
                    richTextBox1.Text += "done ..." + "\n";
                    break;
                }
            }
        }
    }
           
            
