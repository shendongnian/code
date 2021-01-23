    string Test = "1234567890";
    string.Format("Shortened String = {0}", Test.MaxLength(5));
    string.Format("Shortened String = {0}", Test.MaxLength(50));
    Output: 
    Shortened String = 12345
    Shortened String = 1234567890
