    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using ICSharpCode.NRefactory;
    using System.IO;
    using ICSharpCode.NRefactory.Ast;
    using ICSharpCode.NRefactory.Visitors;
    using ICSharpCode.NRefactory.PrettyPrinter;
    namespace Parse
    {
        class Program
        {
            static void Main(string[] args)
            {
                string code = @"using System;
                using System.Collections.Generic;
                using System.Linq;
                namespace MyCode
                {
                    static class MyProg
                    {
                        static void Run()
                        {
                            int i = 0;
                            i++;
                            Log(i);
                        }
                    }
                }
                ";
                IParser p = ParserFactory.CreateParser(SupportedLanguage.CSharp,new StringReader(code));
                p.Parse();
                //Output Original
                CSharpOutputVisitor output = new CSharpOutputVisitor();
                output.VisitCompilationUnit(p.CompilationUnit, null);
                Console.Write(output.Text);
                //Add custom method calls
                AddMethodVisitor v = new AddMethodVisitor();
                v.VisitCompilationUnit(p.CompilationUnit,null);
                v.AddMethodCalls();
                output.VisitCompilationUnit(p.CompilationUnit, null);
                //Output result
                Console.Write(output.Text);
        }
        }
        //The vistor adds method calls after visiting by storing the nodes in a dictionary. 
        public class AddMethodVisitor : ConvertVisitorBase
        {
            private IdentifierExpression member = new IdentifierExpression("MyAdditionalMethod");
            private Dictionary<INode, INode> expressions = new Dictionary<INode, INode>();
            private void AddNode(INode original)
            {
                expressions.Add(original, new ExpressionStatement(new InvocationExpression(member)));
            }
            public override object VisitExpressionStatement(ExpressionStatement expressionStatement, object data)
            {
                AddNode(expressionStatement);
                return base.VisitExpressionStatement(expressionStatement, data);
            }
            public override object VisitLocalVariableDeclaration(LocalVariableDeclaration localVariableDeclaration, object data)
            {
                AddNode(localVariableDeclaration);
                return base.VisitLocalVariableDeclaration(localVariableDeclaration, data);
            }
            public void AddMethodCalls()
            {
                foreach (var e in expressions)
                {
                    InsertAfterSibling(e.Key, e.Value);
                }
            }
        
        }
    }
