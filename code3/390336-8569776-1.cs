    progressBar.Minimum = 0;
    progressBar.Maximum = length;
    using (StreamReader sr = new StreamReader(file,System.Text.Encoding.ASCII))
    {
        while (sr.EndOfStream == false)
        {
            line = sr.ReadLine();
            progressBar.Value += line.Length;
