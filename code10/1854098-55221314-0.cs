    private static Compilation CreateTestCompilation()
    {
        var found = false;
        var di = new DirectoryInfo(Environment.CurrentDirectory);
        var fi = di.GetFiles().Where((crt) => { return crt.Name.Equals("program.cs", StringComparison.CurrentCultureIgnoreCase); }).FirstOrDefault();
        while ((fi == null) || (di.Parent == null))
        {
            di = new DirectoryInfo(di.Parent.FullName);
            fi = di.GetFiles().Where((crt) => { return crt.Name.Equals("program.cs", StringComparison.CurrentCultureIgnoreCase); }).FirstOrDefault();
            if (fi != null)
            {
                found = true;
                break;
            }
        }
        if (!found)
        {
            return null;
        }
        var targetPath = di.FullName +  @"\Program.cs";
        var targetText = File.ReadAllText(targetPath);
        var targetTree =
                       CSharpSyntaxTree.ParseText(targetText)
                                       .WithFilePath(targetPath);
        var target2Path = di.FullName + @"\TypeInferenceRewriter.cs";
        var target2Text = File.ReadAllText(target2Path);
        var target2Tree =
                       CSharpSyntaxTree.ParseText(target2Text)
                                       .WithFilePath(target2Path);
    
        SyntaxTree[] sourceTrees = { programTree, target2Tree };
    
        MetadataReference mscorlib =
                MetadataReference.CreateFromFile(typeof(object).Assembly.Location);
        MetadataReference codeAnalysis =
                MetadataReference.CreateFromFile(typeof(SyntaxTree).Assembly.Location);
        MetadataReference csharpCodeAnalysis =
                MetadataReference.CreateFromFile(typeof(CSharpSyntaxTree).Assembly.Location);
    
        MetadataReference[] references = { mscorlib, codeAnalysis, csharpCodeAnalysis };
    
        return CSharpCompilation.Create("TransformationCS",
                                        sourceTrees,
                                        references,
                                        new CSharpCompilationOptions(
                                                OutputKind.ConsoleApplication));
    }
