    // get component model & Visual Studio Roslyn workspace
    var componentModel = await package.GetServiceAsync<SComponentModel, IComponentModel>();
    var workspace = componentModel.GetService<VisualStudioWorkspace>(); // requires "Microsoft.VisualStudio.LanguageServices" nuget package
    // enum all the projects
    foreach (var project in workspace.CurrentSolution.Projects)
    {
        // enum all the documents in the project
        foreach (var doc in project.Documents)
        {
            // get the semantic model & syntax tree root
            var model = await doc.GetSemanticModelAsync();
            var root = await model.SyntaxTree.GetRootAsync();
            // find a class named "TestBase"
            // ClassDeclarationSyntax etc. requires "Microsoft.CodeAnalysis.CSharp.Workspaces" nuget package
            var myClass = root.DescendantNodes()
                .OfType<ClassDeclarationSyntax>()
                .FirstOrDefault(c => c.Identifier.Text == "TestBase");
            if (myClass != null)
            {
                // find a method named "AddItem"
                var myMethod = myClass.Members.Where(m => m.Kind() == SyntaxKind.MethodDeclaration)
                    .OfType<MethodDeclarationSyntax>()
                    .FirstOrDefault(m => m.Identifier.Text == "AddItem");
                if (myMethod != null)
                {
                    // get the list of method parameters
                    var parameters = myMethod.ParameterList.Parameters;
                    ...
                    // get the start line for the method declaration
                    var lineSpan = model.SyntaxTree.GetLineSpan(myMethod.Span);
                    int startLine = lineSpan.StartLinePosition.Line;
                    ...
                }
            }
        }
    }
