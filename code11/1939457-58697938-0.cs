CSharp
var tree = CSharpSyntaxTree.ParseText(@"
public interface IB
{
}
public interface IA : IB
{
}
public class Letters:IA
{
}
");
var Mscorlib = PortableExecutableReference.CreateFromAssembly(typeof(object).Assembly);
var compilation = CSharpCompilation.Create("MyCompilation",
    syntaxTrees: new[] { tree }, references: new[] { Mscorlib });
var model = compilation.GetSemanticModel(tree);
var myClass = tree.GetRoot().DescendantNodes().OfType<ClassDeclarationSyntax>().Last();
var myClassSymbol = model.GetDeclaredSymbol(myClass);
var interfaces = myClassSymbol.AllInterfaces;
