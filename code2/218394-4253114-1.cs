    List<string> file1Lines = new List<string>();
    List<string> file2Lines = new List<string>();
    while ((line = file.ReadLine()) != null)
    {
        file1Lines.Add(line);
    }
    while ((line2 = file2.ReadLine()) != null)
    {
        file2Lines.Add(line2);
    }
    foreach (string f1line in file1Lines)
    {
        foreach (string f2line in file2Lines)
        {
            if (f1line.Contains(f2line))
            {
                dest.WriteLine("LineNo : " + counter.ToString() + " : " + f1line + "<br />");
            }
        }
        counter++;
    }
