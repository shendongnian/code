    Regex rxSingleCharNewLine = new Regex(@"\r(?!\n)|(?<!\r)\n",RegexOptions.Singleline);
    Regex rxNewLine = new Regex(@"\r\n",RegexOptions.Singleline);
    if(!rxSingleCharNewLine.IsMatch(text) && rxNewLine.IsMatch(text)) {
        // Do stuff 
    }
    else {
        //Error
    }
