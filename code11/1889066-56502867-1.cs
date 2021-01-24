    var processor = new Theraot.Core.StringProcessor(input);
    var results = new List<string>();
    while (!processor.EndOfString)
    {
        processor.SkipWhile(char.IsWhiteSpace); // SkipWhile skips all the characters that match
        if (processor.Read('"')) // Read returns true if what is next matches the paramter
        {
            results.Add(processor.ReadUntil('"')); 
            processor.Read('"'); 
        }
        processor.SkipWhile(char.IsWhiteSpace);
        if (!processor.Read('+'))
        {
            // error?
        }
    }
