SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(@"
public class MyGlobals
{
    public int Age {get; set;} = 21;
}
");
var references = new List<MetadataReference>
{
    MetadataReference.CreateFromFile(typeof(object).Assembly.Location)
};
var compilation = CSharpCompilation.Create("DynamicAssembly")
    .WithOptions(new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary))
    .AddSyntaxTrees(syntaxTree)
    .AddReferences(references);
Type globalsType = null;
Assembly assembly = null;
using (var memoryStream = new MemoryStream())
{
    var compileResult = compilation.Emit(memoryStream);
    var buffer = memoryStream.GetBuffer();
    File.WriteAllBytes("DynamicAssembly.dll", buffer);
    assembly = Assembly.LoadFile(Path.GetFullPath("DynamicAssembly.dll"));
    if (compileResult.Success)
    {
        globalsType = assembly.GetType("MyGlobals");
    }
}
var globals = Activator.CreateInstance(globalsType);
var options = ScriptOptions.Default.WithReferences("DynamicAssembly.dll");
var validationResult = CSharpScript.EvaluateAsync<bool>(
    "Age == 21",
    globals: globals,
    options: options
);
Console.WriteLine(await validationResult);
