    static string ProcessString(string input, string tag)
    {
        var sb = new StringBuilder();
        int depth = 0;
        foreach (var token in Tokenize(input, tag))
        {
            // Append all tags, but only text tokens with depth level 0
            if (token.TypeOfToken != Token.TokenType.Text || 
                (token.TypeOfToken == Token.TokenType.Text && depth == 0))
                sb.Append(input.Substring(token.Start, token.Length));
            else
                sb.Append(new string(' ', token.Length));
                
            // Increment for each starttag, decrement for each endtag, never smaller than 0
            depth = Math.Max(0, depth + (token.TypeOfToken == Token.TokenType.StartTag ? 1 :
                                        (token.TypeOfToken == Token.TokenType.EndTag ? -1 : 0)));
        }
        return sb.ToString();
    }
