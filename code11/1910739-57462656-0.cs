    string result;
    using (StreamReader sr = new StreamReader(textfile))
    {
        while (sr.Peek() >= 0)
        {
            string line = sr.ReadLine();
            if (line.StartsWith("<Visible>"))
            {
                result = sr.ReadLine();
                break;
            }
        }
    }
