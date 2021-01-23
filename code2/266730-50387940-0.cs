    private void CheckCurrentWord()
    {
        // current caret position
        var currentposition = TxtLineCodes.SelectionStart;
        // get line number
        var linenumber = TxtLineCodes.GetLineFromCharIndex(currentposition);
        // get the first character index of the line
        var firstlineindex = currentposition;
        if (linenumber == 0)
        {
            firstlineindex = 0;
        }
        else
        {
            while (TxtLineCodes.GetLineFromCharIndex(firstlineindex) == linenumber)
            {
                firstlineindex--;
            }
            //fix the last iteration
            firstlineindex += 1;
        }
    
        // if caret is not in the end of the word discover it
        var lastcaretwordindex = currentposition;
        if (lastcaretwordindex < TxtLineCodes.Text.Length)
            while (lastcaretwordindex < TxtLineCodes.Text.Length && TxtLineCodes.Text.Substring(lastcaretwordindex, 1) != " ")
            {
                lastcaretwordindex += 1;
            }
    
        // get the text of the line (until the cursor position)
        var linetext = TxtLineCodes.Text.Substring(firstlineindex, lastcaretwordindex - firstlineindex);
        // split all the words in current line
        string[] words = linetext.Split(' ');
        // the last word must be the current word
       System.Diagnostics.Debug.WriteLine("current word: " + words[words.Length - 1]);
        // and you can also get the substring indexes of the current word
        var currentwordbysubstring = TxtLineCodes.Text.Substring(lastcaretwordindex - words[words.Length - 1].Length, words[words.Length - 1].Length);
    
        var startindex = lastcaretwordindex - words[words.Length - 1].Length;
        var lastindex = startindex + words[words.Length - 1].Length-1;
        System.Diagnostics.Debug.WriteLine("current word: " + currentwordbysubstring + " and its in index (" + startindex + "," + lastindex + ")");
    }
