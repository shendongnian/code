    using System;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var tree = SyntaxFactory.ParseExpression("(x + y) * z").SyntaxTree;
                var root = (BinaryExpressionSyntax)tree.GetRoot();
                foreach (var i in root.DescendantNodes())
                {
                    if (i.Kind() == SyntaxKind.IdentifierName)
                    {
                        string str = "64";
                        var subTree = SyntaxFactory.ParseExpression(str).SyntaxTree;
                        var subRoot = (LiteralExpressionSyntax)subTree.GetRoot();
                        var newRoot = SyntaxNodeExtensions.ReplaceNode(root, i, subRoot);
                        Console.WriteLine(newRoot);
                    }
                }
                Console.ReadLine();
            }
        }
    }
