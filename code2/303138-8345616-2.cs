    public static void MarkAsStaticClassWithExtensionMethods(this CodeTypeDeclaration class_)
    {
       class_.Attributes = MemberAttributes.Public;
       class_.StartDirectives.Add(new CodeRegionDirective(
               CodeRegionMode.Start, Environment.NewLine + "\tstatic"));
       class_.EndDirectives.Add(new CodeRegionDirective(
               CodeRegionMode.End, string.Empty));
    }
