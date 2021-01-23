    using System;
    using System.Collections.Generic;
    using System.IO;
    using Microsoft.Data.Schema.ScriptDom;
    using Microsoft.Data.Schema.ScriptDom.Sql;
    
    namespace ConsoleApplication1
    {
        internal class Program
        {
            public static void Main(string[] args)
            {
                string[] queries =
                    {
                        @"select * from table1;",
                        /*Test multiline*/
                        @"select *, 
                                  (select top 1 col1 from anothertable) as col1 from table1;"
                        ,
                        @"select * from table1,  (select col1 from anothertable) as anothertable;",
                        @"select * from table1 where col1=(select top 1 col1 from anothertable)",
                        /*Test invalid syntax ("table" is a reserved word)*/
                        @"select * from table where col1=(select top 1 col1 from anothertable)"
                    };
    
                foreach (string query in queries)
                {
                    Parse(query);
                }
    
                Console.ReadKey();
            }
    
            private static void Parse(string query)
            {
                Console.WriteLine(@"------------------------------------------");
                Console.WriteLine(@"Parsing statement ""{0}""", query);
    
                var parser = new TSql100Parser(false);
    
                IList<ParseError> errors;
                IScriptFragment result = parser.Parse(new StringReader(query), out errors);
    
                if (errors.Count > 0)
                {
                    Console.WriteLine(@"Errors encountered: ""{0}""", errors[0].Message);
                    return;
                }
    
    
                TSqlStatement statement = ((TSqlScript) result).Batches[0].Statements[0];
    
                if (statement is SelectStatement)
                {
                    TableSource tableSource = (((QuerySpecification)((SelectStatement)statement).QueryExpression).FromClauses[0]);
    
                    Console.WriteLine(@"Top level FROM clause at Line {0}, Column {1} (Character Offset {2})",
                                      tableSource.StartLine, tableSource.StartColumn, tableSource.StartOffset);
                    Console.WriteLine();
                    Console.WriteLine();
    
                }
            }
        }
    }
