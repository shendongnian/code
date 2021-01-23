    private int CountNumberOfLinesInCSFilesOfDirectory(string dirPath)
    {
        FileInfo[] csFiles = new DirectoryInfo(txtPath.Text.Trim())
                                    .GetFiles("*.cs", SearchOption.AllDirectories);
     
        int totalNumberOfLines = 0;
        Parallel.ForEach(csFiles, fo =>
        {
            Interlocked.Add(ref totalNumberOfLines, CountNumberOfLine(fo));
        });
        return totalNumberOfLines;
    }
     
    private int CountNumberOfLine(Object tc)
    {
        FileInfo fo = (FileInfo)tc;
        int count = 0;
        int inComment = 0;
        using (StreamReader sr = fo.OpenText())
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                if (IsRealCode(line.Trim(), ref inComment))
                    count++;
            }
        }
        return count;
    }
     
    private bool IsRealCode(string trimmed, ref int inComment)
    {
        if (trimmed.StartsWith("/*") && trimmed.EndsWith("*/"))
            return false;
        else if (trimmed.StartsWith("/*"))
        {
            inComment++;
            return false;
        }
        else if (trimmed.EndsWith("*/"))
        {
            inComment--;
            return false;
        }
     
        return
               inComment == 0
            && !trimmed.StartsWith("//")
            && (trimmed.StartsWith("if")
                || trimmed.StartsWith("else if")
                || trimmed.StartsWith("using (")
                || trimmed.StartsWith("else  if")
                || trimmed.Contains(";")
                || trimmed.StartsWith("public") //method signature
                || trimmed.StartsWith("private") //method signature
                || trimmed.StartsWith("protected") //method signature
                );
    }
