    string source = GetTheString();
    
    //only 0-9 allowed in the string, which almost equals to int.TryParse
    bool allDigits = source.All(char.IsDigit); 
    bool alternative = int.TryParse(source,out result);
    
    //allow other "numbers" like ¼
    bool allNumbers = source.All(char.IsNumber);
    
