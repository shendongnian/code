      public class FsVisitor : CSharpSyntaxWalker
            {
                public override void VisitUsingDirective(UsingDirectiveSyntax node)
                {
                    PrintLn("open {0}", node.Name);
                }
    
                public override void VisitClassDeclaration(ClassDeclarationSyntax node)
                {
                    PrintLn("type {0} =", node.Identifier);
                    Enter();
                    base.VisitClassDeclaration(node);
                    Exit();
                }
    
                public override void VisitMethodDeclaration(MethodDeclarationSyntax node)
                {
                    var isStatic = node.Modifiers.Any(t => t.ValueText == "static");
                    var modifiers = String.Join(" ", node.Modifiers);
    
                    PrintLn("{0}{1} ({2}) = ",
                        isStatic ? $"{modifiers} member " : $"member {modifiers} this.",
                        node.Identifier,
                        String.Join(", ", node.ParameterList.Parameters.Select(p => $"{p.Identifier} : {p.Type}")));
                    Enter();
                    base.VisitMethodDeclaration(node);
                    Exit();
                }
    
                public override void VisitInvocationExpression(InvocationExpressionSyntax node)
                {
                    PrintLn("{0}", node);
                    base.VisitInvocationExpression(node);
                }
    
                private StringBuilder builder = new StringBuilder();
                private int intendLevel = 0;
    
                void Enter() => intendLevel++;
                void Exit() => intendLevel--;
    
                void Print(string format, params object[] args)
                {
                    if (format == null) return;
                    builder.Append('\t', intendLevel);
                    builder.AppendFormat(format, args);
                }
    
                void PrintLn(string format = default, params object[] args)
                {
                    Print(format, args);
                    builder.AppendLine();
                }
    
                public override string ToString() => builder.ToString();
            }
