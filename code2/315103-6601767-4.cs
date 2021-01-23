    using System;
    using Antlr.Runtime;
    using Antlr.Runtime.Tree;
        
    namespace SGL
    {
      public class Test
      {
        public static void Main (string[] args)
        {
          ANTLRStringStream Input = new ANTLRStringStream("int x = 3");
          SGLLexer Lexer = new SGLLexer(Input);
          CommonTokenStream Tokens = new CommonTokenStream(Lexer);
          SGLParser parser = new SGLParser(Tokens);
          CommonTree t = (CommonTree) parser.compilationUnit().Tree;
          CommonTreeNodeStream  treeStream = new CommonTreeNodeStream(t);
          SGLTreeWalker tw = new SGLTreeWalker(treeStream);
          tw.compilationUnit();
        }
      }
    }
