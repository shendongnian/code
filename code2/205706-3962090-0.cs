    using System;
    using System.Collections.Generic; // for List<>
    using System.Drawing; // for Graphics and Font
    
    private List<string> GetWordwrapped(string original)
    {
    	List<string> wordwrapped = new List<string>();
    	
    	Graphics graphics = Graphics.FromHwnd(this.Handle);
    	Font font = new Font("Arial", 10);
    	
    	string currentLine = string.Empty;
    	
    	for (int i = 0; i < original.Length; i++)
    	{
    		char currentChar = original[i];
    		currentLine += currentChar;
    		if (graphics.MeasureString(currentLine, font).Width > 120)
    		{
    			// exceeded length, back up to last space
    			int moveback = 0;
    			while (currentChar != ' ')
    			{
    				moveback++;
    				i--;
    				currentChar = original[i];
    			}
    			string lineToAdd = currentLine.Substring(0, currentLine.Length - moveback);
    			wordwrapped.Add(lineToAdd);
    			currentLine = string.Empty;
    		}
    	}
    	
    	return wordwrapped;
    }
