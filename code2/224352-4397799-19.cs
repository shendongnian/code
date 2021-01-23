    using System;
    using Antlr.Runtime;
    using Antlr.Runtime.Tree;
    using Antlr.StringTemplate;
    
    namespace Demo.Antlr
    {
      class MainClass
      {
        public static void Main (string[] args)
        {
          string expression = "(12.5 + 56 / -7) * 0.5";
          ANTLRStringStream Input = new ANTLRStringStream(expression);  
          ExpressionLexer Lexer = new ExpressionLexer(Input);
          CommonTokenStream Tokens = new CommonTokenStream(Lexer);
          ExpressionParser Parser = new ExpressionParser(Tokens);
          Console.WriteLine(expression + " = " + Parser.parse());
        }
      }
    }
