cs
using var peReader = new PEReader(File.OpenRead(Assembly.GetExecutingAssembly().Location));
var mdReader = peReader.GetMetadataReader();
foreach (var attributeHandle in mdReader.CustomAttributes)
{
    var attribute = mdReader.GetCustomAttribute(attributeHandle);
    var ctorHandle = attribute.Constructor;
    EntityHandle attributeTypeHandle = ctorHandle.Kind switch
    {
        HandleKind.MethodDefinition => mdReader.GetMethodDefinition((MethodDefinitionHandle)ctorHandle).GetDeclaringType(),
        HandleKind.MemberReference => mdReader.GetMemberReference((MemberReferenceHandle)ctorHandle).Parent,
        _ => throw new InvalidOperationException(),
    };
    StringHandle attributeTypeNameHandle = attributeTypeHandle.Kind switch
    {
        HandleKind.TypeDefinition => mdReader.GetTypeDefinition((TypeDefinitionHandle)attributeTypeHandle).Name,
        HandleKind.TypeReference => mdReader.GetTypeReference((TypeReferenceHandle)attributeTypeHandle).Name,
        _ => throw new InvalidOperationException(),
    };
    if (mdReader.StringComparer.Equals(attributeTypeNameHandle, "NullableAttribute"))
    {
        Console.WriteLine(attribute.Parent.Kind);
    }
}
This was provided by https://github.com/dotnet/corefx/issues/40234#issuecomment-520254880
