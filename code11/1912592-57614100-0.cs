    public override Task RegisterCodeFixesAsync(CodeFixContext context)
    {
        var workspace = context.Document.Project.Solution.Workspace;
        //...
    }
