    WyamConfiguration.Embed(engine => {
        engine.FileSystem.InputPaths.Add(new DirectoryPath("Markdown"));
        engine.FileSystem.OutputPath = new DirectoryPath("HtmlOutput");
        engine.Pipelines.Add(new Pipeline(
            "DocumentationPages",
            new ReadFiles("**/*.md"),
            new FrontMatter(new Yaml()),
            new Markdown(),
            new WriteFiles(".html")));
        var docsRecipe = new Docs();
        docsRecipe.Apply(engine);
    });
