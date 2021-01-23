    using(TextReader tr = new StreamReader(filePath))
    {
        StringBuilder sb = new StringBuilder();
        for(string line = tr.ReadLine(); line != null; line = tr.ReadLine())
            if(line == "[new]")
                sb = new StringBuilder("[new]");//flush last chunk read.
            else
                sb.Append('\n').Append(line);
        return sb.ToString();
    }
