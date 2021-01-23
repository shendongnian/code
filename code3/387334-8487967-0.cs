    string[] lines = ...; // Note that I'm using an array here!
    using (...)
    {
        for (int i = 0; i < lines.Length; i++)
        {
            if (i < lines.Length-1 || !condition)
                sw.WriteLine(lines[i]);
        }
    }
