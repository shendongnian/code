    string GenerateCSFromDesigner(DesignSurface designSurface)
    {
        CodeTypeDeclaration type;
        var host = (IDesignerHost)designSurface.GetService(typeof(IDesignerHost));
        var root = host.RootComponent;
        var manager = new DesignerSerializationManager(host);
        using (manager.CreateSession())
        {
            var serializer = (TypeCodeDomSerializer)manager.GetSerializer(root.GetType(),
                typeof(TypeCodeDomSerializer));
            type = serializer.Serialize(manager, root, host.Container.Components);
            type.IsPartial = true;
            type.Members.OfType<CodeConstructor>()
                .FirstOrDefault().Attributes = MemberAttributes.Public;
        }
        var builder = new StringBuilder();
        CodeGeneratorOptions option = new CodeGeneratorOptions();
        option.BracingStyle = "C";
        option.BlankLinesBetweenMembers = false;
        using (var writer = new StringWriter(builder, CultureInfo.InvariantCulture))
        {
            using (var codeDomProvider = new CSharpCodeProvider())
            {
                codeDomProvider.GenerateCodeFromType(type, writer, option);
            }
            return builder.ToString();
        }
    }
