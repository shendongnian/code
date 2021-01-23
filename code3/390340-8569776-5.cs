    progressBar.Minimum = 0;
    progressBar.Maximum = 100;
    long currentPosition = 0;
    using (StreamReader sr = new StreamReader(file,System.Text.Encoding.ASCII))
    {
        while (sr.EndOfStream == false)
        {
            line = sr.ReadLine();
           
            currentPosition += line.Count; // or plus 2 if you need to take into account carriage return
            progressBar.Value = (int)(((decimal)currentPosition / (decimal)length) * (decimal)100);
