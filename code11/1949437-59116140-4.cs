    var reader = File.OpenText(filePAth);
    var startLineDetected = false;
    var startWord = "00:09:08.870";
    var endWord =  "00:09:12.026";
    var strBuilder = new StringBuilder();
    while(!reader.EndOfStream)
    {
        var newLine = reader.ReadLine();
        if(newLine.Contains($"[{startWord}") && !startLineDetected)
        {
            startLineDetected = true;
        }
    
        if(newLine.Contains($"[{endWord}") && startLineDetected)
        {
    		strBuilder.AppendLine(newLine);
            break;
        }
    
        if(startLineDetected)
        {
            strBuilder.AppendLine(newLine);
        }
    }
    var resultData = strBuilder.ToString();
