	var reader = File.OpenText(filePAth);
	var startLineDetected = false;
	var startWord = // startWord;
	var endWord =  // endWord;
	var strBuilder = new StringBuilder();
	while(!reader.EndOfStream)
	{
		var newLine = reader.ReadLine();
		
        if(newLine.Contains(startWord) && !startLineDetected)
        {
            startLineDetected = true;
            newLine = newLine.Substring(newLine.IndexOf(startWord));
        }
    
        if(newLine.Contains(endWord) && startLineDetected)
        {
            newLine = newLine.Substring(0,newLine.IndexOf(endWord) + endWord.Length);
            strBuilder.Append(newLine);
            break;
        }
		
		if(startLineDetected)
		{
			strBuilder.Append(newLine);
		}
	}
    var resultData = strBuilder.ToString();
