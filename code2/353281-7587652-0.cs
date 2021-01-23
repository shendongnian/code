    private void ParseForLongMethods(string path)
        {
            _parser = new Parser(new CSharpGrammar());
            if (_parser == null || !_parser.Language.CanParse()) return;
            _parseTree = null;
            GC.Collect(); //to avoid disruption of perf times with occasional collections
            _parser.Context.SetOption(ParseOptions.TraceParser, true);
            try
            {
                string contents = File.ReadAllText(path);
                _parser.Parse(contents);//, "<source>");
            }
            catch (Exception ex)
            {
            }
            finally
            {
                _parseTree = _parser.Context.CurrentParseTree;
                TraverseParseTree();
            }
        }
