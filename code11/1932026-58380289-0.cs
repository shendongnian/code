    switch (context.Node)
            {
                case JoinIntoClauseSyntax joinIntoClause:
                    if (IsNotValid(joinIntoClause.Identifier.Text))
                        context.ReportDiagnostic(Diagnostic.Create(Rule, joinIntoClause.Identifier.GetLocation(), joinIntoClause.Identifier.Text));
                    break;
                case QueryContinuationSyntax continuationSyntax:
                    if (IsNotValid(continuationSyntax.Identifier.Text))
                        context.ReportDiagnostic(Diagnostic.Create(Rule, continuationSyntax.Identifier.GetLocation(), continuationSyntax.Identifier.Text));
                    break;
            }
