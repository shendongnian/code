            var dependencies = new Dictionary<string, List<string>>(); 
            //key - class name, value - list of dependent class names
            var project = workspace.CurrentSolution.Projects.First();
            foreach (var document in project.Documents)
            {
                var semanticModel = await document.GetSemanticModelAsync();
                KeyValuePair<string, List<string>>? keyValue = null;
                foreach (var item in semanticModel.SyntaxTree.GetRoot().DescendantNodes())
                {
                    switch (item)
                    {
                        case ClassDeclarationSyntax classDeclaration:
                        case InterfaceDeclarationSyntax interfaceDeclaration:
                            if (!keyValue.HasValue)
                            {
                                keyValue = new KeyValuePair<string, List<string>>(semanticModel.GetDeclaredSymbol(item).Name, new List<string>());
                            }
                            break;
                        case SimpleBaseTypeSyntax simpleBaseTypeSyntax:
                            keyValue?.Value.Add(simpleBaseTypeSyntax.Type.ToString());
                            break;
                        case ParameterSyntax parameterSyntax:
                            keyValue?.Value.Add(parameterSyntax.Type.ToString());
                            break;
                    }
                }
                if (keyValue.HasValue)
                {
                    dependencies.Add(keyValue.Value.Key, keyValue.Value.Value);
                }
            }
