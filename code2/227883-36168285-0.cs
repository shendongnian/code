    using System.IO;
	public void newMethod()
    {
    	//get path of the textfile
    	string textToEdit = @"D:\textfile.txt";
    	//read all lines of text
    	List<string> allLines = File.ReadAllLines(textToEdit).ToList();
        
    	//from Devendra's answer
    	if (allLines.Contains(stringToAdd))
	    {
	        allLines.Remove(stringToAdd);
	    }
	    else
	    {
	        allLines.Add(stringToAdd);
	    }
    	//extra: get index and edit
    	int i = allLines.FindIndex(stringToEdit => stringToEdit.Contains("need to edit")) ;
        allLines[i] = "edit";
        //save all lines
    	File.WriteAllLines(textToEdit, allLines.ToArray());
    }
