    using Microsoft.Data.Schema.ScriptDom;
    using Microsoft.Data.Schema.ScriptDom.Sql;
    
    .....
            string sql = "SELECT * FROM SomeTable WHERE (1=1";
            var p = new TSql100Parser(true);
            IList<ParseError> errors;
            p.Parse(new StringReader(sql), out errors);
            if (errors.Count == 0)
                Console.Write("No Errors");
            else
                foreach (ParseError parseError in errors)
                    Console.Write(parseError.Message);
