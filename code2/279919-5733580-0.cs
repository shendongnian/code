        internal static string CreateAstSexpression(string filename)
        {
            using (var fs = File.OpenRead(filename))
            {
                using (var parser = ParserFactory.CreateParser(SupportedLanguage.CSharp,
                                                               new StreamReader(fs)))
                {
                    parser.Parse();
                    // RetrieveSpecials() returns an IList<ISpecial>
                    // parser.Lexer.SpecialTracker.RetrieveSpecials()...
                    // "specials" == comments, preprocessor directives, etc.
                    // parser.CompilationUnit retrieves the root node of the result AST
                    return SexpressionGenerator.Generate(parser.CompilationUnit).ToString();
                }
            }
        }
