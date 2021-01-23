    IEnumerable<string> LineSplitter(string line)
    {
        int fieldStart = 0;
        for(int i = 0; i < line.Length; i++)
        {
            if(line[i] == ',')
            {    
                yield return line.SubString(fieldStart, i - fieldStart - 1);
                fieldStart = i + 1;
            }
            if(line[i] == '"')
                for(i++; line[i] != '"'; i++)
        }
    }
