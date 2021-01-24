    List<string> clippedLines = new List<string>();
    for(int x = 0; x < textBox1.Lines.Length; x++)
        clippedLines.Add(textBox1.Lines[x].Length > 0 ?  
                         textBox1.Lines[x].Substring(1) : "");
     
    // Replacing the whole Lines array will work   
    textBox1.Lines = clippedLines.ToArray();
