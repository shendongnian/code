        private static TokenListParser<SyntaxKind, StatementSyntax> ParseExpressionStatement(
                bool lookForTerminator)
        {
            return from expression in ParsePrefixExpression.Or(ParseCallExpression())
                    from terminator in lookForTerminator
                        ? MatchToken(SyntaxKind.SemiColon).OptionalOrDefault()
                        : PassThrough(Token<SyntaxKind>.Empty)
                    select (StatementSyntax) new ExpressionStatementSyntax(expression, terminator);
        }
        private static TokenListParser<T, Token<T>> PassThrough<T>(Token<T> empty)
        {
            return input =>
            {
                var output = input.ConsumeToken();
                return TokenListParserResult.Value(empty, output.Location, output.Location);
            };
        }
        
