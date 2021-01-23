    private static IEnumerable<Token> Tokenize(string input)
    { 
        var startIndex = 0;
        var endIndex = 0;
        while (endIndex < input.Length)
        {            
            if (char.IsDigit(input[endIndex]))
            {
                while (char.IsDigit(input[++endIndex]));
                var value = input.SubString(startIndex, endIndex - startIndex);
                yield return new Token(value, TokenType.Number);
            }
            else if (input[endIndex] == '-')
            {
                yield return new Token("-", TokenType.Dash);
            }
            else
            {
                yield return new Token(input[endIndex].ToString(), TokenType.Error);
            }
            startIndex = ++endIndex;
        }
    }
