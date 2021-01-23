    using System;
    using Antlr.Runtime;
    
    namespace Demo
    {
        class MainClass
        {
            public static void Main (string[] args)
            {
                string source = 
    @"class TestClass
    {
        int a = 42;
    
        string _class = ""inside a string literal: class FooBar {}..."";
    
        class Nested { 
            /* class NotAClass {} */
    
            // class X { }
            
            class DoubleNested {
                string str = @""
                    multi line string 
                    class Bar {}
                "";
            }
        }
    }";
    			Console.WriteLine("source=\n" + source + "\n-------------------------");
                ANTLRStringStream Input = new ANTLRStringStream(source);
                CSharpClassLexer Lexer = new CSharpClassLexer(Input);
                CommonTokenStream Tokens = new CommonTokenStream(Lexer);
                Tokens.GetTokens();
            }
        }
    }
