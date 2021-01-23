    var unit = new CodeCompileUnit();
    var @namespace = new CodeNamespace("GeneratedCode");
    unit.Namespaces.Add(@namespace);
    // AddDefault() doesn't exist, but you can create it as an extension method
    @namespace.Imports.AddDefault();
    @namespace.Imports.Add(new CodeNamespaceImport("MyApi.CoolNameSpace"));
    var @class = new CodeTypeDeclaration("GeneratedClass");
    @namespace.Types.Add(@class);
    @class.TypeAttributes = TypeAttributes.Class | TypeAttributes.Public;
    var constructor = new CodeConstructor();
    constructor.Attributes = MemberAttributes.Public;
    constructor.Parameters.Add(
        new CodeParameterDeclarationExpression(typeof(string), "name"));
    constructor.Statements.Add(…);
    @class.Members.Add(constructor);
    var provider = new CSharpCodeProvider();
    var result = provider.CompileAssemblyFromDom(new CompilerParameters(), unit);
