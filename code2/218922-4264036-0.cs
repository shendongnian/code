    HashSet<string> names = new HashSet<string>();
    foreach (String r in lines)
    {
        if (r.StartsWith("User Name"))
        {
            String[] token = r.Split(' ');
            string name = token[11];
            if (names.Add(name))
            {
                Console.WriteLine(name);
            }
        }
    }
