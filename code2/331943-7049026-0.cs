    while ((line = tr.ReadLine()) != null)
    {
        String[] details = line.Split('\t');
        if (details.Length == 1)
        {
            // Or log it, or whatever...
            Console.WriteLine("Input error: no tab in line '{0}'", line);
        }
        else
        {
            accounts.Add(details[0] + ":" + details[1]);
        }
    }
