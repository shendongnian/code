    static void Main()
    {
        const string content = "\v\U00010330";
    
        string newContent = RemoveInvalidXmlChars(content);
        Console.WriteLine(newContent);
    }
