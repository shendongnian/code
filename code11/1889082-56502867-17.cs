    var processor = new Theraot.Core.StringProcessor(input);
    var results = new List<string>();
    while (!processor.EndOfString)
    {
        // SkipWhile skips all the characters that match
        processor.SkipWhile(char.IsWhiteSpace);
        // Read returns true (and advances after) if what is next matches the paramter
        if (processor.Read('"'))
        {
            // ReadUntil advances after and returns everything found before the parameter 
            // Note: it does not advance after the parameter.
            results.Add(processor.ReadUntil('"'));
            processor.Read('"'); 
        }
        processor.SkipWhile(char.IsWhiteSpace);
        if (!processor.Read('+'))
        {
            // error?
        }
    }
