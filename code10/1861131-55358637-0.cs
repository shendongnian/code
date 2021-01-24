    string inputText = textBox1.Text;
    List<string> outputLines = new List<string>();
    
    HashSet<string> seenLines = new HashSet<string>();
    bool seenEmptyLine = false;
    
    string[] lines = inputText.Split('\n');
    
    foreach(string line in lines)
    {
        string trimmedLine = line.Trim();
    
        if(trimmedLine == "")
        {
            // When we see an empty line, we remember that we have seen one
            seenEmptyLine = true;
        }
        else
        {
            // When we see a non-empty line, we add it only when we have not seen it before
            if(seenLines.Contains(trimmedLine))
            {
                // Seen line before, skip it
            }
            else
            {
                // Remember we have seen this line
                seenLines.Add(trimmedLine);
    
                // if we have seen an empty line since adding last line,
                // add empty line
                if(seenEmptyLine)
                {
                    seenEmptyLine = false;
                    outputLines.Add("");
                }
    
                outputLines.Add(trimmedLine);
            }
        }
    
    }
    
    string outputText = string.Join(Environment.NewLine, outputLines);
    
    textBox2.Text = outputText;
