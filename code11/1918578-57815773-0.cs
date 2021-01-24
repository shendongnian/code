    using (StreamReader sr = File.OpenText(datafile))
    {
        string line = sr.ReadLine();
        while (line != null)
        {
            count = count ++;
            if (count % 2 == 0)
            {
                string[] splitline = line.Split(' ');
                string datanumber = splitline[0].Trim('>');
                index.Add(datanumber, count);
            }
            line = sr.ReadLine();
        }
    }
