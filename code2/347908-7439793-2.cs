    static IEnumerable<Token> Tokenize(string input, string tag)
    {
        int index = 0;
        int lastIndex = 0;
            
        // Define the start and end tag and their common first character
        char tagChar = '<';
        string startTag = tag + '>';
        string endTag = '/' + tag + '>';
        while (true)
        {
            Token token = null;
            // Search for any new tag token
            index = input.IndexOf(tagChar, index) + 1;
            if (index <= 0)
                break;
            // Starttag or endtag token found
            if (input.Substring(index, startTag.Length) == startTag)
                token = new Token { Start = index - 1, Length = startTag.Length + 1, TypeOfToken = Token.TokenType.StartTag };
            else if (input.Substring(index, endTag.Length) == endTag)
                token = new Token { Start = index - 1, Length = endTag.Length + 1, TypeOfToken = Token.TokenType.EndTag };
            // Yield the text right before the tag and the tag itself
            if (token != null)
            {
                yield return new Token { Start = lastIndex, Length = index - lastIndex - 1, TypeOfToken = Token.TokenType.Text };
                yield return token;
                lastIndex = index + token.Length - 1;
            }
        }
        // Yield last text token
        yield return new Token { Start = lastIndex, Length = input.Length - lastIndex, TypeOfToken = Token.TokenType.Text };
    }
    class Token
    {
        public int Start { get; set; }
        public int Length { get; set; }
        public TokenType TypeOfToken { get; set; }
        public enum TokenType
        {
            Text,
            StartTag,
            EndTag
        }
    }
