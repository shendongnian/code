    var words = currentText.Split(new [] { ' ' }, 
                                  StringSplitOptions.RemoveEmptyEntries);
    string currentlyTyped = words.LastOrDefault();
If you are worried about performance/user experience problems with splitting words everytime you type, you can just analyse last character and append it to some currentWord:
    // in your event handler
    char newestChar = this.myRichTextBox.Text.LastOrDefault();
    if (char.IsWhiteSpace(newestChar))
    {
        this.currentWord = ""; // entered whitespace, reset current
    }
    else 
    {
        this.currentWord = currentWord + newestChar;
    }
    
