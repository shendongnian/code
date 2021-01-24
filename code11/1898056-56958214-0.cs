    /// <summary>
    /// Parses any character other than whitespace or brackets.
    /// </summary>
    public static TextParser<char> NonWhiteSpaceOrBracket =>
        from c in Character.Except(c => 
            char.IsWhiteSpace(c) || c == '{' || c == '}',
            "Anything other than whitespace or brackets"
        )
        select c;
    /// <summary>
    /// Parses any piece of valid text, i.e. any text other than whitespace or brackets.
    /// </summary>
    public static TextParser<string> TextContent =>
        from content in NonWhiteSpaceOrBracket.Many()
        select new string(content);
    /// <summary>
    /// Parses an encoded piece of text enclosed in brackets.
    /// </summary>
    public static TextParser<string> EncodedContent =>
        from open in Character.EqualTo('{')
        from text in TextContent
        from close in Character.EqualTo('}')
        select text;
    /// <summary>
    /// Parse a single content, e.g. "name{variable}" or just "name"
    /// </summary>
    public static TextParser<string[]> Content =>
        from text in TextContent
        from encoded in EncodedContent.OptionalOrDefault()
        select encoded != null ? new[] { text, encoded } : new[] { text };
    /// <summary>
    /// Parse multiple contents and flattens the result.
    /// </summary>
    public static TextParser<string[]> AllContent =>
        from content in Content.ManyDelimitedBy(Span.WhiteSpace)
        select content.SelectMany(x => x.Select(y => y)).ToArray();
