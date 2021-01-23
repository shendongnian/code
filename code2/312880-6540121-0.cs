    string FileMerger()
    {
        var file1 = File.ReadAllLines(@"c:\....\File1.txt");
        var file2 = File.ReadAllLines(@"c:\....\File2.txt");
	
        var file1Lines = file1.Select(f => f.Split('\t')).ToDictionary(f => f[1], f => f);
        var file2Lines = file2.Select(f => f.Split('\t')).ToDictionary(f => f[0], f => f[1].Split(','));
	
        StringBuilder newOutput = new StringBuilder();
	
        foreach(var line in file1Lines) 
        {
            if(file2Lines.ContainsKey(line.Key)) 
            {
                newOutput.Append(Combine(line.Value, file2Lines[line.Key]));
            }
            else 
            {
                newOutput.AppendLine(string.Join("\t", line.Value));
            }
        }
	
        return newOutput.ToString();
    }
    string Combine(string[] file1Line, string[] file2Line)
    {
        StringBuilder builder = new StringBuilder();
	
        foreach(var str in file2Line)
        {
            builder.AppendLine(string.Format("{0}\t{1}\t{2}\t{3}\t{4}", file1Line[0], str, file1Line[2], file1Line[3], file1Line[1].EndsWith("A") ? "T" : "B"));
        }
	
        return builder.ToString();
    }
