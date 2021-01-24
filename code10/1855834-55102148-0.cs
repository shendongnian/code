    using System;
    using System.Linq;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    
    public class SanpleClass
    {
        public static void Main()
        {
            var str =
                @"
                namespace Sample
                {
                    public interface IBar
                    {
                        void Do();
                    }
    
                    public class Foo
                    {
                        private IBar _bar;
                    }
                }";
    
            var syntaxTree = SyntaxFactory.ParseSyntaxTree(str);
    
            var compilation = CSharpCompilation.Create("Sample", new[] { syntaxTree });
    
            var semanticModel = compilation.GetSemanticModel(syntaxTree, true);
    
            var classDeclarationSyntax =
                semanticModel.SyntaxTree.GetRoot().DescendantNodes().OfType<ClassDeclarationSyntax>().First();
    
            var fieldDeclarationSyntax = classDeclarationSyntax.DescendantNodes().OfType<FieldDeclarationSyntax>().First();
    
            var typeKind = semanticModel.GetTypeInfo(fieldDeclarationSyntax.Declaration.Type).Type.TypeKind;
    
            var isInterface = typeKind == TypeKind.Interface;
    
            Console.WriteLine($"Is Interface: {isInterface}");
        }
    }
