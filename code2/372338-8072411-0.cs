    StringBuilder builder = new StringBuilder(BIGSTRINGLEN);
    foreach (var line in File.ReadLines(filename))
    {
        // clean up the line.
        // Do you really want to replace tabs with nothing?
        // if you want to treat tabs like spaces, change the call to Split
        // and include '\t' in the character array.
        string finish = line.Replace("\t", string.Empty);
        string[] seeit = finish.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
        foreach (string word in seeit)
        {
            if ((builder.Length + word.Length + 1 <= BIGSTRINGLEN)
            {
                if (builder.Length != 0)
                    builder.Append(' ');
                builder.Append(word);
            }
            else
            {
                // output line
                Console.WriteLine(builder.ToString());
                // and reset the builder
                builder.Length = 0;
            }
        }
    }
    // and write the last line
    if (builder.Length > 0)
        Console.WriteLine(builder.ToString());
