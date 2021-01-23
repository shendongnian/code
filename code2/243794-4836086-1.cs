    string[] articleWords = textBoxText.Split(' ');
    articleWords = articleWords.Select(a => a.Trim()).ToArray();    // remove all whitespaces (blanks, linebreaks)
    articleWords = articleWords.Where(a => !string.IsNullOrEmpty(a)).ToArray(); // remove empty strings
    
    bool correct = false;
    bool spellingErrorFound = false;
    for (int i = 0; i < articleWords.Length; i++)
    {
        string checkedWord = articleWords[i].TrimEnd('?', '.', ',', '!');
        correct = _spellChecker.CheckWord(checkedWord);
    
        if (!correct)
            spellingErrorFound = true;
    }
