    var foldercontent = Directory.GetFiles(pathA)
                        .Select(filename => new
                        {
                            Filename = filename,
                            Lines = File.ReadAllLines(filename)
                        })
                        .SelectMany(file => file.Lines.Select((line, idx) => new
                        {
                            LineNumber = idx + 1,
                            Text = line,
                            FileName = file.Filename
                        }));
    
    var pattern = File.ReadAllLines(pathB);
    
    var result = from fileLine in foldercontent
                    where pattern.Any(p => fileLine.Text.IndexOf(p, StringComparison.CurrentCultureIgnoreCase) != -1)
                    select fileLine;
    
    foreach (var match in result)
    {
        System.Diagnostics.Debug.WriteLine("File: {0} LineNo: {1}: Text: {2}", match.FileName, match.LineNumber, match.Text);
    }
