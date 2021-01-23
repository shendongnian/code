            public EnumDeclarationSyntax GenerateEnum()
        {
            var loanPurpose = new[]
            {
                "Business Launching",
                "HomePurchase",
                "HomeImprovement"
            };
            var enumDescriptions = new[]
            {
                "Launch a new business",
                "Buy a home",
                "Make home improvements"
            };
            var i = 0;
            var members = new List<EnumMemberDeclarationSyntax>();
            foreach (var item in loanPurpose)
            {
                var attribute = SyntaxFactory.Attribute(
                    SyntaxFactory.IdentifierName("Description"));
                var attributeArgument = SyntaxFactory.AttributeArgument(
                    SyntaxFactory.LiteralExpression(
                        SyntaxKind.StringLiteralExpression,
                        SyntaxFactory.Literal(enumDescriptions[i ])));
                attribute = attribute.WithArgumentList(
                    SyntaxFactory.AttributeArgumentList(
                        SyntaxFactory.SingletonSeparatedList(attributeArgument)));
                var attributes = SyntaxFactory.SingletonList(
                    SyntaxFactory.AttributeList(SyntaxFactory
                        .SingletonSeparatedList(attribute)));
                var objectCreationExpression = SyntaxFactory.EqualsValueClause(
                    SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression,
                        SyntaxFactory.Literal(i)));
                var member = SyntaxFactory.EnumMemberDeclaration(attributes, 
                    SyntaxFactory.Identifier(item),
                    objectCreationExpression);
                members.Add(member);
                i++;
            }
            var declaration = SyntaxFactory.EnumDeclaration
                (new SyntaxList<AttributeListSyntax>(),
                baseList: null,
                identifier: SyntaxFactory.Identifier("LoanPurpose"),
                modifiers: SyntaxFactory.TokenList(SyntaxFactory.Token(SyntaxKind.PublicKeyword)),
                members: SyntaxFactory.SeparatedList(members)
                );
            return declaration;
        }
