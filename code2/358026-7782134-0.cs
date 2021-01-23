    using VeParser;
    using System.Linq;
    using System.Collections.Generic;
    using System;
    
    public class MDXParser : TokenParser
    {
        protected override Parser GetRootParser()
        {
            // read the following line as : fill 'select' property of 'current object(which is a statement)' with the 'new value of selectStatement' after facing a sequence of a select statement and then the symbol of ( and then a delemitied list of identierfiers filling the 'fileds' property of 'current selectStatement object' delemitied by ',' and finally expect the sequence to be finished with a symbol of ')'
            var selectStatement = fill("select", create<selectStatment>( seq(expectKeyword_of("select"), expectSymbol_of("("), deleimitedList(expectSymbol_of(","), fill("fields",identifier) ), expectSymbol_of(")"))));
            // read the following line as : fill the from property of 'current object(which is a statement)' with an expected identifier that is after a 'from' keyword
            var fromStatement = seq(expectKeyword_of("from"), fill("from", identifier));
            // the following statement is incomplete, as I just wanted to show a sample bit, If you are interested I can help you complete the parser until the full documentation become available.
            var whereStatement = fill("where", create<whereStatement>(seq(expectKeyword_of("where"))));
            var statement = create<statement>(seq(selectStatement, fromStatement, whereStatement));
            
            return statement;
        }
        public statement Parse(string code)
        {
            var keywords = new[] { "select", "where", "from" };
            var symbols = new[] { "(",")", ".", "[", "]" };
            var tokenList = Lexer.Parser(code, keywords, symbols, ignoreWhireSpaces : true);
            // Now we have our string input converted into a list of tokens which actually is a list of words but with some additional information about any word, for example a "select" is marked as keyword
            var parseResult = base.Parse(tokenList.tokens);
            if (parseResult == null)
                throw new Exception("Invalid Code, at the moment Ve Parser does not support any error reporting feature.");
            else
                return (statement)parseResult;
        }
    }
    public class statement
    {
        public selectStatment select;
        public string where;
        public identifier from;
    }
    public class selectStatment
    {
        public List<identifier> fields;
    }
    public class whereStatement
    {
    }
