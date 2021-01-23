    using System;
    using Antlr.Runtime;
    using Antlr.Runtime.Tree;
    using Antlr.StringTemplate;
    
    namespace Demo.Antlr
    {
      class MainClass
      {
        public static void Preorder(ITree Tree, int Depth) 
        {
          if(Tree == null)
          {
            return;
          }
    
          for (int i = 0; i < Depth; i++)
          {
            Console.Write("  ");
          }
    
          Console.WriteLine(Tree);
    
          Preorder(Tree.GetChild(0), Depth + 1);
          Preorder(Tree.GetChild(1), Depth + 1);
        }
    
        public static void Main (string[] args)
        {
          ANTLRStringStream Input = new ANTLRStringStream("(12.5 + 56 / -7) * 0.5"); 
          ExpressionLexer Lexer = new ExpressionLexer(Input);
          CommonTokenStream Tokens = new CommonTokenStream(Lexer);
          ExpressionParser Parser = new ExpressionParser(Tokens);
          ExpressionParser.parse_return ParseReturn = Parser.parse();
          CommonTree Tree = (CommonTree)ParseReturn.Tree;
          Preorder(Tree, 0);
        }
      }
    }
