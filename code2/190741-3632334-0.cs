    using (IParser parser = ParserFactory.CreateParser(SupportedLanguage.CSharp, new StringReader(sourceCode))) 
    {
    	parser.Parse();
    	// this allows retrieving comments, preprocessor directives, etc. (stuff that isn't part of the syntax)
    	specials = parser.Lexer.SpecialTracker.RetrieveSpecials();
    	// this retrieves the root node of the result AST
    	result = parser.CompilationUnit;
    	if (parser.Errors.Count > 0) {
    		MessageBox.Show(parser.Errors.ErrorOutput, "Parse errors");
    	}
    }
