    foreach (string item in vars.directory)
    {
        reader2 = new StreamReader(item);
        while (reader2.Peek() > 0)
        {
            string line = reader2.ReadLine();
            // new code
            vars.words[counter] = new List<string>();
            vars.hints[counter] = new List<string>();
    
            if (line.StartsWith("#"))
            {
                vars.words[counter].Add(line.Substring(1, line.Length - 1)); //here
            }
            else if (line.StartsWith("-"))
            {
                vars.hints[counter].Add(line.Substring(1, line.Length - 1)); //another here
            }
            else if (line == "@end")
            {
                counter++;
            }
        }
    }
